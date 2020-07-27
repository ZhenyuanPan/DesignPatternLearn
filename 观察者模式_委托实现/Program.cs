using System;
using System.Xml.Serialization;

namespace 观察者模式_委托实现
{
    //看股票的同事
    class StorckObserver 
    {
        private string name;
        private Subject sub;
        public StorckObserver(string name,Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        //关闭股票行情
        public void CloseStocckMarket()
        {
            Console.WriteLine("{0} {1} 关闭股票行情，继续工作！",sub.SubjectState,name);
        }
    }

    //看NBA的同事
    class NBAObserver
    {
        private string name;
        //依赖倒置 依赖抽象不依赖具体
        private Subject sub;
        public NBAObserver(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public void CloseNBADirectSeeding() 
        {
            Console.WriteLine("{0} {1} 关闭NBA直播, 继续工作!",sub.SubjectState,name);
        }
    }


    //通知者接口
    interface Subject
    {
        void Notify();
        string SubjectState { get; set; }
    }

    //具体通知者 比如老板
    class Boss : Subject
    {
        public Action update;

        private string bossAction;
        public string SubjectState { get => bossAction; set => bossAction = value; }

        public void Notify()
        {
            update.Invoke();
        }
    }

    class Program
    {
        //客户端代码
        static void Main(string[] args)
        {
            //老板
            Boss huhansan = new Boss();
            //看股票的同事
            StorckObserver tongshi1 = new StorckObserver("未关注",huhansan);
            //看NBA的同事
            NBAObserver tongshi2 = new NBAObserver("易观察",huhansan);

            //注册事件 
            //委托是一种特殊的数据类型 他储存的是方法 

            //huhansan.update += new Action(tongshi1.CloseStocckMarket);
            //huhansan.update += new Action(tongshi2.CloseNBADirectSeeding);

            //func(); 表示执行了方法 得到了相应的返回值，委托是注册方法 而不是注册返回值！别弄错了
            huhansan.update += tongshi1.CloseStocckMarket;
            huhansan.update += tongshi2.CloseNBADirectSeeding;

            //老板回来了
            huhansan.SubjectState = "老板回来了!";
            //发出通知
            huhansan.Notify();
        }
    }
}
