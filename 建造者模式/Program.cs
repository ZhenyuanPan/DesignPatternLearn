using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//建造者模式是在当创建复杂对象的算法应该独立于该对象的组成部分以及他们的装配方式时适用的模式
namespace 建造者模式
{
    //product 类___产品类，由多个部件组成
    class Product
    {
        IList<string> parts = new List<string>();
        /// <summary>
        /// 添加产品部件
        /// </summary>
        /// <param name="part"></param>
        public void Add(string part) 
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\n 产品 创建-----");

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    /// <summary>
    /// Bulider 类____抽象建造者类，确定产品由两个部件PartA 和 PartB 组成, 并声明一个得到产品建造后结果的方法GetResult
    /// </summary>
    abstract class Builder
    {
        public abstract void BulidPartA();
        public abstract void BulidPartB();
        public abstract Product GetProduct();
    }

    //ConcreteBulider1 类_____具体建造者类
    class ConcreteBulider1 : Builder
    {
        private Product product = new Product();
        public override void BulidPartA()
        {
            product.Add("部件 A");
        }

        public override void BulidPartB()
        {
            product.Add("部件 B");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }

    //ConcreteBulider2 类_____具体建造者类
    class ConcreteBulider2 : Builder
    {
        private Product product = new Product();
        public override void BulidPartA()
        {
            product.Add("部件 X");
        }

        public override void BulidPartB()
        {
            product.Add("部件 Y");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }

    //Director 类_____ 指挥者类 用来指挥建造过程
    class Director 
    {
        public void Construct(Builder builder)
        {
            builder.BulidPartA();
            builder.BulidPartB();
        }
        
    }




    class Program
    {
        //客户端代码  客户不需要知道具体的建造过程
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder b1 = new ConcreteBulider1();
            Builder b2 = new ConcreteBulider2();

            director.Construct(b1);
            director.Construct(b2);

            Product p1 = b1.GetProduct();
            p1.Show();
            Product P2 = b2.GetProduct();
            P2.Show();
        }
    }
}
