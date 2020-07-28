using System;
using System.Collections.Generic;

//组合模式 定义了包含基本对象和组合对象的类层次结构。基本对象可以被组合成更复杂的组合对象，而这个组合对象又可以被组合，这样不断地递归下去，
//客户端代码中，任何用到基本对象的地方都可以使用组合对象了
namespace 组合模式
{
    //Component 为组合中的对象声明接口，在适当情况下，实现所有类共有接口的默认行为。声明一个接口用于访问和管理Component的子部件
    abstract class Component 
    {
        protected string name;
        public Component(string name) { this.name = name; }
        //通常都使用Add和Remove方法来提供增加或者移除树叶或者树枝的功能
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    //leaf 在组合中表示叶子节点对象 叶节点没有子节点
    //由于叶子不能再增加叶子和分支,所以add和remove方法没有实现它的意义。但这样做可以消除叶节点和枝节点对象在抽象层次的区别，他们具有完全一致的接口
    class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {

        }
        public override void Add(Component c)
        {
            Console.WriteLine("叶节点无法添加分支和树叶");
        }

        //叶节点的具体方法，此处显示其名称和级别
        public override void Display(int depth)
        {
            Console.WriteLine(new String('*',depth) + name);
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("叶节点无法删除分支和树叶");
        }
    }

    // Composite 定义有枝节点 用来储存子部件, 在Component接口中实现与子部件有关的操作, 比如增加Add和删除Remove
    class Composite : Component
    {
        public Composite(string name) : base(name) 
        {
            
        }

        //一个子对象集合用来储存其下属的枝节点和叶节点
        private List<Component> children = new List<Component>();

        public override void Add(Component c)
        {
            children.Add(c);
        }

        //实现枝节点名称，并对其下级进行遍历
        public override void Display(int depth)
        {
            Console.WriteLine(new String('*', depth) + name);
            foreach (var component in children)
            {
                component.Display(depth+2);
            }
        }

        public override void Remove(Component c)
        {
            children.Remove(c);
        }
    }


    class Program
    {
        //客户端代码, 能通过Component接口操作组合部件的对象
        static void Main(string[] args)
        {
            Composite root = new Composite("Root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);

            Composite comp2 = new Composite("Composite XY");
            comp.Add(comp2);

            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);
            
        }
    }
}
