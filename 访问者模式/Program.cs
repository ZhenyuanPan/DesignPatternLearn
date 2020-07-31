using System;
using System.Collections.Generic;

//访问者模式: 表示一个作用于某对象结构中的各元素的操作。它使你可以在不改变各元素的类的前提下定义作用于这些元素的新操作

//访问者模式适用于数据结构相对稳定的系统(比如人 就分为男人女人两种), 他把数据结构和作用于结构上的操作之间的耦合解脱开, 使得操作几何可以性对自由地演化

//访问者模式的目的是要把处理从数据结构分离出来, 有比较稳定的数据结构, 又有易于变化的算法的话, 使用访问者模式就是比较合适的, 因为访问者模式使得算法操作的增加变的容易

//访问者模式的优点就是增加新的操作很容易, 因为增加新的操作就意味着增加一个新的访问者。访问者模式将有关的行为集中到一个访问者对象中

//访问者模式的缺点其实也就是使增加新的数据结构变的困难了
namespace 访问者模式
{
    //Visitor 类,为该类对象结构中ConcreteElement的每一个类声明一个Visit操作
    abstract class Visitor 
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }
    class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0}被{1}访问",concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0}被{1}访问", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }

    class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0}被{1}访问", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            Console.WriteLine("{0}被{1}访问", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }
    //Element类, 定义一个Accept操作, 它以一个访问者为参数
    abstract class Element 
    {
        public abstract void Accept(Visitor visitor);
    }
    //ConcreteElementA 和 ConcreteElementB类, 具体元素, 实现Accept操作
    class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
        //其他关联方法
        public void OperationA() { }
    }

    class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
        //其他关联方法
        public void OperationB() { }
    }

    //ObjectStructure类, 能枚举它的元素, 可以提供一个高层的接口以允许访问者访问它的元素
    class ObjectStrcture 
    {
        private List<Element> elements = new List<Element>();
        public void Attach(Element element) 
        {
            elements.Add(element);
        }
        public void Detach(Element element) 
        {
            elements.Remove(element);
        }
        public void Accept(Visitor visitor) 
        {
            elements.ForEach(e => e.Accept(visitor));
        }
    }


    class Program
    {
        //客户端代码
        static void Main(string[] args)
        {
            ObjectStrcture o = new ObjectStrcture();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            ConcreteVisitor2 v2 = new ConcreteVisitor2();

            o.Accept(v1);
            o.Accept(v2);
        }
    }
}
