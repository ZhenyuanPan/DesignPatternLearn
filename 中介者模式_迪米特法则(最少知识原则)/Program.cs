using System;

//迪米特法则: 如果两个类不必彼此直接通讯, 那么这两个类就不应当发生直接相互作用。如果其中一个类需要调用另一个类的某一个方法的话，可以通过第三者转发这个调用。
//中介者对象的设计, 使得系统的结构不会因为新对象的引用造成大量的修改工作

//中介者模式: 用一个中介对象来封装一系列的对象交互。中介者使各对象不需要显示地相互引用，从而使其耦合松散，而且可以独立地改变他们之间的交互
namespace 中介者模式_迪米特法则_最少知识原则_
{
    //Mediator类 抽象中介者
    public abstract class Mediator 
    {
        public abstract void Send(string message, Colleague colleague);
    }

    //Colleague 类 抽象同事类
    public abstract class Colleague 
    {
        protected Mediator mediator;
        //构造方法  得到中介者对象
        public Colleague(Mediator mediator) 
        {
            this.mediator = mediator;
        }
    }

    //ConcreteMediator类 具体中介者类
    public class ConcreteMediator: Mediator 
    {
        private ConcreteColleague_A colleague_A;
        private ConcreteColleague_B colleague_B;

        public ConcreteColleague_A Colleague_A { set => colleague_A = value; }
        public ConcreteColleague_B Colleague_B { set => colleague_B = value; }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague_A)
            {
                colleague_B.Notify(message);
            }
            else 
            {
                colleague_A.Notify(message);
            }
        }
    }

    public class ConcreteColleague_B : Colleague
    {
        public ConcreteColleague_B(Mediator mediator):base(mediator) { }
        public void Notify(string message)
        {
            Console.WriteLine("同事B得到的消息:"+message);
        }
        //发送信息时通常是由中介者发送出去的
        public void Send(string message) 
        {
            mediator.Send(message,this);
        }
    }

    public class ConcreteColleague_A : Colleague
    {
        public ConcreteColleague_A(Mediator mediator) : base(mediator) { }
        public void Notify(string message)
        {
            Console.WriteLine("同事A得到的消息:" + message);
        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //中介者
            ConcreteMediator m = new ConcreteMediator();

            //让两个具体同事认识中介者对象
            ConcreteColleague_A ca = new ConcreteColleague_A(m);
            ConcreteColleague_B cb = new ConcreteColleague_B(m);

            m.Colleague_A = ca;
            m.Colleague_B = cb;

            ca.Send("吃过饭了吗?");
            cb.Send("没有呢");
        }
    }
}
