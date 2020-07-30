using System;
//继承是一种强耦合的结构，父类变, 子类就必须要变
//合成聚合复用原则: 尽量使用合成/聚合, 尽量不要使用类继承
//聚合: 个体 与 群体, 大雁 燕群
//合成: 部分 与 个体, 翅膀 大雁
//同时符合开放-封闭原则, 这样的设计显然不会修改原来的代码。而只是扩展类就好了。
namespace 不要滥用继承_合成聚合复用原则
{
    //手机软件
    abstract class HandsetSoft 
    {
        public abstract void Run();
    }

    //手机游戏, 通讯录等具体类
    class HandsetGame : HandsetSoft 
    {
        public override void Run()
        {
            Console.WriteLine("运行手机游戏");
        }
    }

    //手机通讯录
    class HandsetAddressList : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机通讯录");
        }
    }

    //手机品牌类
    abstract class HandsetBrand 
    {
        protected HandsetSoft soft;
        //设置手机软件
        public void SetHandsetSoft(HandsetSoft soft) 
        {
            this.soft = soft;
        }

        //运行
        public abstract void Run();
    }

    //品牌N 品牌M具体类
    class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
    class HandsetBrandM : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            HandsetBrand ab;
            ab = new HandsetBrandN();
            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();

            ab = new HandsetBrandM();
            ab.SetHandsetSoft(new HandsetAddressList());
            ab.Run();

        }
    }
}
