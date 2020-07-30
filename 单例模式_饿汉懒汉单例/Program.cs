using System;

namespace 单例模式_饿汉懒汉单例
{
    //懒汉单例 懒汉式面临着多线程访问的安全性问题,需要做双重锁定这样的处理才能保证安全
    class SingletonLanHan 
    {
        private SingletonLanHan() { }
        private static SingletonLanHan instance;
        //双重锁定处理多线程下的单例问题 静态初始化 当类加载时候就会实例化
        private static readonly object syncRoot = new object();
        public static SingletonLanHan GetInstance() 
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new SingletonLanHan();
                    }
                }
            }
            return instance;
        }
    }

    //饿汉单例 静态初始化的方式，它是类一加载就实例化的对象, 所以要提前占用系统资源。
    //防止派生, 派生会增加实例
    sealed class SingletonEHan 
    {
        //静态初始化的方式是在自己被加载的时候就将自己实例化 
        private static readonly SingletonEHan instance = new SingletonEHan();
        private SingletonEHan() { }
        public static SingletonEHan GetInstance() 
        {
            return instance;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
