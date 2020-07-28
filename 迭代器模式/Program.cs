using System;
using System.Collections.Generic;

//集成于各类高级面向对象语言中 现在学习价值大于实用价值。研究历史是为了更好的未来。
//迭代器模式就是分离了集合对象的遍历行为，抽象出一个迭代器类来负责, 这样既可以做到不暴露集合的内部结构，又可以让外部代码透明的访问集合内部的数据
namespace 迭代器模式
{
    //Iterator 迭代器抽象类
    //用于定义得到开始对象，得到下一个对象，判断是否到结尾，当前对象等抽象方法，统一接口
    abstract class Iterator 
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    //Aggregate 聚集抽象类
    abstract class Aggregate 
    {
        //创建迭代器
        public abstract Iterator CreateIterator();
    }


    //ConcreteIterator 具体迭代器类, 继承Iterator
    class ConcreteIterator : Iterator
    {
        //定义了一个具体聚集对象
        private ConcreteAggregate aggregate;
        private int current = 0;


        public ConcreteIterator(ConcreteAggregate aggregate) 
        {
            this.aggregate = aggregate;
        }

        //返回当前的聚集对象 利用索引器
        public override object CurrentItem()
        {
            return aggregate[current];
        }

        //得到聚集的第一个对象 利用索引器实现获取list[0]
        public override object First()
        {
           
            return aggregate[0];
        }

        //判断当前是否遍历到结尾，到结尾返回true
        public override bool IsDone()
        {
            return current >= aggregate.Count ? true : false;
        }

        //得到聚集的下一个对象
        public override object Next()
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }
    }

    //为啥要把iterator抽象出来? 因为可以定制化对聚集的遍历方式 比如从后往前遍历
    class ConcreteIteratorDesc : Iterator 
    {
        private ConcreteAggregate aggregate;
        private int current = 0;
        public ConcreteIteratorDesc(ConcreteAggregate aggregate) 
        {
            this.aggregate = aggregate;
            current = aggregate.Count - 1;
        }

        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override object First()
        {
            return aggregate[aggregate.Count - 1];
        }

        public override bool IsDone()
        {
            return current < 0 ? true : false;
        }

        public override object Next()
        {
            object ret = null;
            current--;
            if (current>=0)
            {
                ret = aggregate[current];
            }
            return ret;
        }

    }




    //ConcreteAggregate 具体聚集类 继承Aggregate
    class ConcreteAggregate : Aggregate
    {
        //声明一个list泛型变量 ， 用于存放聚合对象，用ArrayList同样可以实现
        private List<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        //返回聚集总个数
        public int Count 
        {
            get => items.Count;
        }
        //声明一个索引器
        public object this[int index] { get => items[index];set => items.Insert(index, value); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //公交车 即聚集对象
            ConcreteAggregate a = new ConcreteAggregate();
            //索引器 给list赋值 新上来的乘客, 即对象数组
            a[0] = "大鸟";
            a[1] = "小菜";
            a[2] = "行李";
            a[3] = "老外";
            a[4] = "公交内部员工";
            a[5] = "小偷";

            //售票员出场, 先看好了山车的是哪些人, 即声明了迭代器对象
            //Iterator i = new ConcreteIterator(a);
            //提供了聚集对象自己创建迭代器对象的接口
            Iterator o = a.CreateIterator();
            //售票员从后往前查看
            Iterator i = new ConcreteIteratorDesc(a);


            //从第一个乘客开始
            object item = i.First();

            while (!i.IsDone())
            {
                Console.WriteLine("{0} 请购买车票!",i.CurrentItem());
                i.Next();
            }
        }
    }
}
