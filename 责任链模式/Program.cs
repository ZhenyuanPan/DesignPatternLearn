using System;
using System.Linq;

//责任链模式: 使多个对象都有机会处理请求，从而避免请求的发送者和接受者之间的耦合关系。这个对象连成一条链，并沿着这条链传递该请求，直到有一个对象处理它为止
namespace 责任链模式
{
    //Handler类,定义一个处理请示的接口
    abstract class Handler 
    {
        protected Handler successor;
        //设置继任者
        public void SetSuccessor(Handler successor) 
        {
            this.successor = successor;
        }
        //处理请求的抽象方法
        public abstract void HandleRequest(int request);
    }

    //ConcreteHandler类, 具体处理者类, 处理它所负责的请求, 可访问它的后继者, 如果可处理该请求就处理 , 否则就将该请求转发给它的后继者
    //ConcreteHandler1类, 当请求数在0 到 9 则有权处理, 否则转到下一位。
    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request<10)
            {
                Console.WriteLine( "{0} 处理请求 {1}",this.GetType().Name, request);
            }
            else if(successor != null)
            {
                //传递给下一位处理者对象
                successor.HandleRequest(request);
            }
        }
    }

    //ConcreteHandler2, 当请求数在10 到 19 则有权处理。否则转到下一位
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} 处理请求 {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                //传递给下一位处理者对象
                successor.HandleRequest(request);
            }
        }
    }

    //ConcreteHandler3, 当请求数在20 到 29 则有权处理。否则转到下一位
    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} 处理请求 {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                //传递给下一位处理者对象
                successor.HandleRequest(request);
            }
        }
    }

    class Program
    {
        //客户端代码, 向链上的具体处理者兑现提交请求
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            //设置职责链的上家与下家
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            int[] requests = { 2,5,12,22,15,4,27,20};

            //循环给最小处理者提交请求, 不同的数额, 由不同权限处理者处理
            requests.ToList().ForEach(e => h1.HandleRequest(e));
        }
    }
}
