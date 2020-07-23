using System;

namespace 装扮模式_小菜扮靓
{
    /// <summary>
    /// ConcreteComponent
    /// </summary>
    class Person
    {
        public Person() 
        {

        }

        private string name;
        public Person( string name) 
        {
            this.name = name;
        }

        public virtual void Show() 
        {
            Console.WriteLine("装扮的{0}",name);
        }
    }

    /// <summary>
    /// 服饰类 Decorator
    /// </summary>
    class Finery: Person 
    {
        private Person component;
        //打扮
        public void Decorate(Person component) 
        {
            this.component = component;
        }

        public override void Show()
        {
            if (component != null)
            {
                component.Show();
            }
        }
    }


    /// <summary>
    /// 具体服饰类 ConcreteDecorator
    /// </summary>
    class TShirts : Finery 
    {
        public override void Show()
        {
            Console.Write("大T恤 ");
            base.Show();
        }
    }

    class BigTrouser : Finery 
    {
        public override void Show()
        {
            Console.Write("垮裤 ");
            base.Show();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //一层一层往上执行
            Person xc = new Person("小菜");
            Console.WriteLine("\n 第一种装扮:");

            TShirts shirts = new TShirts();
            BigTrouser bigTrouser = new BigTrouser();

            shirts.Decorate(xc);
            bigTrouser.Decorate(shirts);

            bigTrouser.Show();
        }
    }
}
