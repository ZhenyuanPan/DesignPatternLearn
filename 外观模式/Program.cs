using System;


/// <summary>
/// 外观模式Facade:
/// 为子系统中的一组接口提供一个一致的界面，此模式定义了一个高层接口,这个接口使得这一子系统更加容易使用
/// </summary>
namespace 外观模式
{
    //四个子系统的类
    class SubSystemOne
    {
        public void MethodOne() 
        {
            Console.WriteLine("子系统方法一");

        }
    }
    class SubSystemTwo
    {
        public void MethodTwo() 
        {
            Console.WriteLine("子系统方法二");

        }
    } 
    class SubSystemThree
    {
        public void MethodThree() 
        {
            Console.WriteLine("子系统方法三");

        }
    }
    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("子系统方法四");

        }
    }

    //外观类 它需要了解所有的子系统的方法或属性，进行组合，以备外界调用
    class Facade 
    {
        SubSystemOne one;
        SubSystemTwo two;
        SubSystemThree three;
        SubSystemFour four;

        public Facade() 
        {
            one = new SubSystemOne();
            two = new SubSystemTwo();
            three = new SubSystemThree();
            four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\n 方法组A() ----");
            one.MethodOne();
            two.MethodTwo();
            four.MethodFour();
        }
        public void MethodB()
        {
            Console.WriteLine("\n 方法组B() ----");
            two.MethodTwo();
            three.MethodThree();
        }
    }

    class Program
    {
        //客户端调用
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }
}
