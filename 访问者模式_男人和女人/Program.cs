using System;
using System.Collections.Generic;

namespace 访问者模式_男人和女人
{
    //'状态'的抽象类 和 '人'的抽象类
    abstract class Action 
    {
        //得到男人结论或反应
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }

    abstract class Person 
    {
        //接受
        public abstract void Accept(Action visitor);
    }
    /*
    * 双分派的技术: 首先在客户程序中将具体状态传递给"男人"类完成了一次分派, 然后"男人"类调用作为参数的"具体状态"中的方法"男人反应",同时将自己(this)作为
    * 参数传递进去。这便完成了第二次分派。双分派意味着得到执行的操作决定于请求的种类和两个接受者的类型。‘接受’方法就是一个双分派的操作，她得道执行的操作
    * 不仅决定于‘状态’类的具体状态，还决定与它访问的‘人’的类别
    */
    class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }
    class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }

    class Success : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0} {1}时, 背后多半有一个伟大的女人。",concreteElementA.GetType().Name,this.GetType().Name);
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0} {1}时, 背后大多有一个不成功的男人。", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }

    //对象结构类 由于总是'男人'与'女人'在不同状态的对比, 所以我们需要一个'对象结构'类来针对不同的'状态'遍历'男人'与'女人', 得到不同的反应
    class ObjectStructure 
    {
        private List<Person> elements = new List<Person>();
        //增加
        public void Attach(Person element) 
        {
            elements.Add(element);
        }
        //移除
        public void Detach(Person element) 
        {
            elements.Remove(element);
        }
        //查看显示
        public void Display(Action visitor) 
        {
            foreach (var item in elements)
            {
                item.Accept(visitor);
            }
        }
    }


   

    class Program
    {
        //客户端代码
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new Man());
            o.Attach(new Woman());
            //成功时的反应
            Success v1 = new Success();
            o.Display(v1);

        }
    }
}
