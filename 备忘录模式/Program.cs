using System;

namespace 备忘录模式
{
    //发起人
    class Originator 
    {
        private string state;
        public string State 
        {
            get => state;
            set => state = value;
        }
        public Memento CreateMemento() 
        {
            return (new Memento(state));
        }
        public void SetMemento(Memento memento) 
        {
            state = memento.State;
        }

        public void Show() 
        {
            Console.WriteLine("State="+ state);
        }
    }
    //备忘录
    class Memento 
    {
        private string state;
        public Memento(string state) 
        {
            this.state = state;
        }
        public string State 
        {
            get => state;
        }
    }
    //管理者
    class Caretaker 
    {
        private Memento memento;
        public Memento Memento 
        {
            get => memento;
            set => memento = value;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "on";
            o.Show();

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "off";
            o.Show();

            o.SetMemento(c.Memento);
            o.Show();
        }
    }
}
