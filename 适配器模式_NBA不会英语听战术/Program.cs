using System;

namespace 适配器模式_NBA不会英语听战术
{
    //球员
    abstract class Player 
    {
        protected string name;
        public Player(string name) 
        {
            this.name = name;
        }
        public abstract void Attact();
        public abstract void Defense();
    }

    //前锋
    class Forwards : Player 
    {
        public Forwards(string name) : base(name) {}

        public override void Attact()
        {
            Console.WriteLine("前锋{0}进攻",name);
        }

        public override void Defense()
        {
            Console.WriteLine("前锋{0}防守",name);
        }
    }


    //外籍中锋 听不懂英文
    class ForeignCenter
    {
        private string name;
        public string Name { get => name; set => name = value; }
        public void JinGong() 
        {
            Console.WriteLine("外籍中锋{0}进攻",name);
        }
        public void FangShou() 
        {
            Console.WriteLine("外籍中锋{0}防守",name);
        }
    }

    //翻译者
    class Translator : Player
    {
        private ForeignCenter wjzf = new ForeignCenter();

        public Translator(string name) : base(name)
        {
            wjzf.Name = name;
        }

        public override void Attact()
        {
            wjzf.JinGong();
        }

        public override void Defense()
        {
            wjzf.FangShou();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Player wjzf = new Translator("姚明");
            Player b = new Forwards("麦迪");

            wjzf.Attact();
            wjzf.Defense();

        }
    }
}
