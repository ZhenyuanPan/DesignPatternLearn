using System;

namespace 代理模式
{
    /// <summary>
    /// 代理接口
    /// </summary>
    interface IGiveGift 
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }

    /// <summary>
    /// 追求者
    /// </summary>
    class Pursuit : IGiveGift
    {
        SchoolGirl mm;

        public Pursuit(SchoolGirl mm) 
        {
            this.mm = mm;
        }

        public void GiveChocolate()
        {
            Console.WriteLine("给" + mm.Name + "巧克力");
        }

        public void GiveDolls()
        {
            Console.WriteLine("给" + mm.Name + "洋娃娃");
        }

        public void GiveFlowers()
        {
            Console.WriteLine("给" + mm.Name + "鲜花");
        }
    }

    /// <summary>
    /// 代理类
    /// </summary>
    class Proxy : IGiveGift
    {
        Pursuit pursuit;

        public Proxy(SchoolGirl mm) 
        {
            pursuit = new Pursuit(mm);
        }

        public void GiveChocolate()
        {
            pursuit.GiveChocolate();
        }

        public void GiveDolls()
        {
            pursuit.GiveDolls();
        }

        public void GiveFlowers()
        {
            pursuit.GiveFlowers();
        }
    }



    class SchoolGirl 
    {
        private string name;
        public SchoolGirl(string name) 
        {
            this.name = name;
        }
        public string Name { get => name; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl schoolGirlJiaoJiao = new SchoolGirl("娇娇");
            Proxy daili = new Proxy(schoolGirlJiaoJiao);
            daili.GiveChocolate();
            daili.GiveDolls();
            daili.GiveFlowers();
        }
    }
}
 