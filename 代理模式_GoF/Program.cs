using System;

namespace 代理模式_GoF
{
    /// <summary>
    /// 定义了RealSubject 和 Proxy的公共接口，这样就可以在任何使用RealSubject的地方都可以使用Proxy
    /// </summary>
    abstract class Subject 
    {
        public abstract void Request();
    }
    /// <summary>
    /// 定义了Proxy 所代理的真实实体
    /// </summary>
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("真实的请求");
        }
    }
    /// <summary>
    /// 保存一个RealSubject引用 使得代理可以访问实体，并提供一个与Subject的接口相同的接口。这样代理就可以用来代替实体
    /// </summary>
    class Proxy : Subject
    {
        RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }
}
