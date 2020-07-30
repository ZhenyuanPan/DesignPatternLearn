using System;
namespace 中介者模式_联合国机构_安理会做中介
{
    //联合国机构类 相当于Mediator类
    abstract class UnitedNations 
    {
        //声明
        public abstract void Declare(string message, Country country);
    }

    //国家类 相当于Colleague类
    abstract class Country 
    {
        protected UnitedNations mediator;

        public Country(UnitedNations mediator) { this.mediator = mediator; }
    }

    //美国类 相当于ConcreteColleague_A 类
    class USA : Country 
    {
        public USA(UnitedNations mediator) : base(mediator) { }

        //声明
        public void Declare(string message) 
        {
            mediator.Declare(message,this);
        }

        //获得信息
        public void GetMessage(string message) 
        {
            Console.WriteLine("美国获得对方信息:"+message);
        }
    }

    //伊拉克类 相当于ConcreteColleague_B 类
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator) : base(mediator) { }

        //声明
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }

        //获得信息
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息:" + message);
        }
    }

    //联合国安理会 相当于ConcreteMediator类
    class UnitedNationSecurityCouncil : UnitedNations
    {
        private USA colleagueA;
        private Iraq colleagueB;
        public USA ColleagueA { set => colleagueA = value; }
        public Iraq ColleaguaB { set => colleagueB = value; }
        public override void Declare(string message, Country country)
        {
            if (country == colleagueA)
            {
                colleagueB.GetMessage(message);
            }
            else 
            {
                colleagueA.GetMessage(message);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            UnitedNationSecurityCouncil UNSC = new UnitedNationSecurityCouncil();
            USA c1 = new USA(UNSC);
            Iraq c2 = new Iraq(UNSC);

            UNSC.ColleagueA = c1;
            UNSC.ColleaguaB = c2;

            c1.Declare("不准研制核武器, 否则发动战争");
            c2.Declare("我们没有核武器, 也不怕侵略");
        }
    }
}
