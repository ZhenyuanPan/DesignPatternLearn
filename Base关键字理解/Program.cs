using System;

namespace Base关键字理解
{
    class A 
    {
        public A()
        {
            Console.WriteLine("A默认构造函数");
        }
        public A(string str) 
        {
            Console.WriteLine("A带参数构造函数:"+str);
        }
    }

    class B : A 
    {
        public B()
        {
            Console.WriteLine("B默认构造函数");
        }
        public B(string str1) 
        {
            Console.WriteLine("B带一参数构造函数:str1:{0}", str1);
        }
        //public B(string str1) : base(str1)
        //{
        //    Console.WriteLine("B带一参数构造函数:str1:{0}", str1);
        //}
        public B(string str1,string str2)
        {
            Console.WriteLine("B带双参数构造函数:str1:{0},str2:{1}",str1,str2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            Console.WriteLine("------------------------------");
            B b1 = new B("参数1");
            Console.WriteLine("------------------------------");
            B b2 = new B("参数1","参数2");
            Console.WriteLine("-------------总结--------------");
            Console.WriteLine(
                "不写base的话默认先执行父类的*默认构造函数(无参数)*" +
                "(子类构造函数后面写不写base() 都会这样（相当于默认后面加了个:base() ），如果父类没有无参数默认构造函数不指定base构造函数则编译不通过)," +
                "根据子类构造函数中base关键字提供的参数选择执行父类中对应参数的构造函数,"
                );
        }
    }
}
