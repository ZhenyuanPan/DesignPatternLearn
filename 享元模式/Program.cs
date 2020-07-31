using System;
using System.Collections.Generic;

//享元模式 : 运用共享技术有效的支持大量细粒度的对象

namespace 享元模式
{
    //Flyweight类, 它是所有具体享元类的超类或接口, 通过这个接口, Flyweight可以接受并作用于外部状态
    abstract class Flyweight 
    {
        public abstract void Operation(int extrinsicstate);
    }

    //ConcreteFlyweight类是继承Flyweight超类或实现Flyweight接口, 并为内部状态增加储存空间
    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体Flyweight:"+extrinsicstate);
        }
    }
    //UnsharedConcreteFlyweight是指那些不需要共享的Flyweight子类。因为Flyweight接口成为可能，但它并不强制共享
    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("不共享的具体Flyweight:" + extrinsicstate);
        }
    }
    /*FlyweightFactory 是一个享元工厂, 用来创建并管理Flyweight对象。它主要是来确保合理地共享Flyweight，当用户请求一个Flyweight时，FlyweightFactory对象
    提供一个已创建的实例或者建立一个（如果不存在的话）。*/
    class FlyweightFactory 
    {
        private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();
        public FlyweightFactory() 
        {
            flyweights.Add("X",new ConcreteFlyweight());
            flyweights.Add("Y",new ConcreteFlyweight());
            flyweights.Add("Z",new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key) 
        {
            return flyweights[key];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweightFactory f = new FlyweightFactory();
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate); 
            Flyweight fy = f.GetFlyweight("Y");
            fx.Operation(--extrinsicstate);
            Flyweight fz = f.GetFlyweight("Z");
            fx.Operation(--extrinsicstate);

            Flyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--extrinsicstate);

        }
    }
}
