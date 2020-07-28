using System;

namespace 备忘录模式_游戏角色状态存档
{
    class GameRole 
    {
        private int vitality;
        public int Vitality { get => vitality; set => vitality = value; }
        private int attack;
        public int Attack { get => attack; set => attack = value; }
        private int defense;
        public int Defense { get => defense; set => defense = value; }

        //显示状态
        public void StateDisplay() 
        {
            Console.WriteLine("角色当前状态:");
            Console.WriteLine("体力:"+ vitality);
            Console.WriteLine("攻击力:"+ Attack);
            Console.WriteLine("防御力:"+ Defense);
        }

        //初始化状态
        public void GetInitState() 
        {
            this.attack = 100;
            this.defense = 100;
            this.vitality = 100;
        }

        //状态清零
        public void Fight() 
        {
            vitality = 0;
            defense = 0;
            attack = 0;
        }

        //保存角色状态
        public RoleStateMemento SaveState() 
        {
            return new RoleStateMemento(vitality,attack,defense);
        }

        //恢复角色状态
        public void RecoveryState(RoleStateMemento memento) 
        {
            this.vitality = memento.Vitality;
            this.attack = memento.Attack;
            this.defense = memento.Defense;
        }
    }

    //角色状态储存箱类
    class RoleStateMemento 
    {
        private int vit;
        private int atk;
        private int def;
        public RoleStateMemento(int vit, int atk, int def) 
        {
            this.atk = atk;
            this.vit = vit;
            this.def = def;
        }
        public int Vitality { get => vit; set => vit = value; }
        public int Attack { get => atk; set => atk = value; }
        public int Defense { get => def; set => def = value; }

    }

    //角色状态管理类
    class RoleStateCaretaker 
    {
        private RoleStateMemento memento;
        public RoleStateMemento Memento { get => memento; set => memento = value; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //大战Boss前
            GameRole player = new GameRole();
            player.GetInitState();
            player.StateDisplay();

            //保存进度
            RoleStateCaretaker stateAdmin = new RoleStateCaretaker();
            stateAdmin.Memento = player.SaveState();

            //战斗后损耗严重
            player.Fight();
            player.StateDisplay();

            //读档
            player.RecoveryState(stateAdmin.Memento);
            player.StateDisplay();
        }
    }
}
