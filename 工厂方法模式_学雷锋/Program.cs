using System;

namespace 工厂方法模式_学雷锋
{
    class LeiFeng
    {
        public void Sweep()
        {
            Console.WriteLine("扫地");
        }

        public void Wash()
        {
            Console.WriteLine("洗衣");
        }

        public void BuyRice()
        {
            Console.WriteLine("买米");
        }
    }

    //学雷锋的大学生
    class Undergraduate : LeiFeng
    {

    }
    //社区志愿者
    class Volunteer : LeiFeng
    {

    }

    //雷锋工厂
    interface IFactory 
    {
        LeiFeng CreateLeiFeng();
    }

    //学雷锋的大学生工厂
    class UndergraduateFactory : IFactory 
    {
        public LeiFeng CreateLeiFeng() 
        {
            return new Undergraduate();
        }
    }

    //志愿者工厂
    class VolunteerFactory : IFactory 
    {
        public LeiFeng CreateLeiFeng() 
        {
            return new Volunteer();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IFactory undergraduteFactory = new UndergraduateFactory();
            IFactory volunteerFactory = new VolunteerFactory();
            LeiFeng student = undergraduteFactory.CreateLeiFeng();
            LeiFeng volunteer = volunteerFactory.CreateLeiFeng();
        }
    }
}
