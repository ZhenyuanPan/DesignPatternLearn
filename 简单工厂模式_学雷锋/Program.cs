using System;

namespace 简单工厂模式_学雷锋
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
    //简单雷锋工厂
    class SimpleFactory 
    {
        public static LeiFeng CreateLeiFeng(string type) 
        {
            LeiFeng result = null;
            switch (type)
            {
                case "大学生":
                    result = new Undergraduate();
                    break;
                case "志愿者":
                    result = new Volunteer();
                    break;
                default:
                    break;
            }
            return result;
        }
    }
   
    class Program
    {
        //客户端代码 大量重复代码
        static void Main(string[] args)
        {
            LeiFeng studentA = SimpleFactory.CreateLeiFeng("大学生");
            studentA.BuyRice();
            LeiFeng studentB = SimpleFactory.CreateLeiFeng("大学生");
            studentB.Sweep();
            LeiFeng volunteerB = SimpleFactory.CreateLeiFeng("志愿者");
            volunteerB.Wash();
        }
    }
}
