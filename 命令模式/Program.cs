using System;

namespace 命令模式
{
    //Receiver类 知道如何实施与执行一个与请求相关的操作, 任何类都可能座位一个接受者
    class Receiver 
    {
        public void Action() 
        {
            Console.WriteLine("执行请求!");
        }
    }
    //Command 类, 用来声明执行操作的接口
    abstract class Command 
    {
        protected Receiver receiver;
        public Command(Receiver receiver) 
        {
            this.receiver = receiver;
        }
        abstract public void Execute();
    }
    //ConcreteCommand 类, 将一个接受者对象绑定于一个动作, 调用接受者响应的操作, 以实现Execute
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) 
        {
            
        }
        public override void Execute()
        {
            receiver.Action();
        }
    }
    //Invoker类, 要求该命令执行这个请求
    class Invoker 
    {
        private Command command;
        public void SetCommand(Command command) 
        {
            this.command = command;
        }
        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    class Program
    {
        //客户端代码: 创建一个具体命令对象并设定它的接受者
        static void Main(string[] args)
        {
            //烤肉师傅
            Receiver r = new Receiver();
            //服务员
            Command c = new ConcreteCommand(r);
            //顾客
            Invoker i = new Invoker();

            i.SetCommand(c);
            i.ExecuteCommand();

        }
    }
}
