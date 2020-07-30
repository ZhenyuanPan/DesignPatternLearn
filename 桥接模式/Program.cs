using System;
//桥接模式: 实现系统可能有多角度分类，每一种分类都有可能变化, 那么就把这种多角度分离出来让它们独立变化, 减少他们之间的耦合
//真正深入的理解设计原则: 很多设计模式其实就是原则的应用而已, 或许在不知不觉中就在使用设计模式了
namespace 桥接模式
{
    abstract class Implementor 
    {
        public abstract void Operation();
    }

    class ConcreteImplementorA : Implementor 
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }

    class ConcreteImplementorB : Implementor 
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }
    }

    class Abstraction 
    {
        protected Implementor implementor;
        public void SetImplementor(Implementor implementor) 
        {
            this.implementor = implementor;
        }
        public virtual void Operation() 
        {
            implementor.Operation();
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();
            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();
        }
    }
}
