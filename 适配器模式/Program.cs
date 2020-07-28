using System;

namespace 适配器模式
{
    //Target 客户所期待的接口。目标可以是具体的或者抽象的类,也可以是接口
    class Target 
    {
        public virtual void Request() 
        {
            Console.WriteLine("普通请求");
        }
    }

    //Adaptee(需要适配的类)代码如下(受改造者)
    class Adaptee 
    {
        public void SpecificRequest() 
        {
            Console.WriteLine("特殊请求");
        }
    }

    //Adapter(通过在内部包装一个Adaptee对象，把源接口转换成目标接口)代码如下(适配器)
    class Adapter : Target 
    {
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }


    class Program
    {
        //对于客户端来说，调用的就是Target 的 Request()
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();

        }
    }
}
