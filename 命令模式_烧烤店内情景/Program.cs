using System;
using System.Collections.Generic;

namespace 命令模式_烧烤店内情景
{
    //烤串师傅
    public class Barbecuer 
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串!");
        }

        public void BakeChickenWing() 
        {
            Console.WriteLine("烤鸡翅!");
        }
    }

    //抽象命令类
    public abstract class Command 
    {
        protected Barbecuer receiver;
        public Command(Barbecuer receiver) 
        {
            this.receiver = receiver;
        }
        abstract public void ExcuteCommand();
    }

    //具体命令类
    class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer barbecuer) : base(barbecuer) 
        {

        }
        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer barbecuer) : base(barbecuer)
        {

        }
        public override void ExcuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }

    //服务员
    public class Waitar 
    {
        private List<Command> orders = new List<Command>();
        //设置订单
        public void SetOrder(Command command) 
        {
            orders.Add(command);
            Console.WriteLine("增加订单:"+ command.ToString() + ",时间:"+ DateTime.Now.ToString());
        }

        //取消订单
        public void CancelOrder(Command command) 
        {
            orders.Remove(command);
            Console.WriteLine("取消订单:" + command.ToString()+",时间:"+DateTime.Now.ToString());
        }

        //通知全部执行
        public void Notify() 
        {
            orders.ForEach(e => e.ExcuteCommand());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //开店前的准备
            Barbecuer barbecuer = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(barbecuer);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(barbecuer);
            Command bakeChickenWingCommand = new BakeChickenWingCommand(barbecuer);
            Waitar waitar = new Waitar();

            //开门营业 顾客点菜
            waitar.SetOrder(bakeMuttonCommand1);
            waitar.SetOrder(bakeMuttonCommand2);
            waitar.SetOrder(bakeChickenWingCommand);

            //点菜完毕 通知后厨
            waitar.Notify();

        }
    }
}
