using System;
using System.Collections.Generic;

namespace 组合模式_公司管理系统
{
    //公司类 抽象类或接口
    abstract class Company 
    {
        protected string name;
        public Company(string name) 
        {
            this.name = name;
        }

        public abstract void Add(Company company);//增加
        public abstract void Remove(Company company);//移除
        public abstract void Display(int depth);//显示
        public abstract void LineOfDuty();//履行职责
    }

    //具体公司类 实现接口 树枝节点
    class ConcreteCompany : Company
    {
        private List<Company> children = new List<Company>();

        public ConcreteCompany(string name):base(name) 
        {
            
        }

        public override void Add(Company company)
        {
            children.Add(company);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('*',depth)+name);
            foreach (var item in children)
            {
                item.Display(depth+2);
            }
        }

        //履行职责
        public override void LineOfDuty()
        {
            foreach (var item in children)
            {
                item.LineOfDuty();
            }
        }

        public override void Remove(Company company)
        {
            children.Remove(company);
        }
    }

    //人类资源部与财务部 树枝节点

    //人类资源部
    class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name) 
        {
            
        }

        public override void Add(Company company)
        {
           
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('*', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 员工招聘培训管理",name);
        }

        public override void Remove(Company company)
        {
            
        }
    }

    //财务部
    class FinanceDepartment : Company 
    {
        public FinanceDepartment(string name) : base(name) { }

        public override void Add(Company company)
        {
           
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('*', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 公司财务收支调用",name);
        }

        public override void Remove(Company company)
        {
            
        }
    }


    class Program
    {
        //客户端调用
        static void Main(string[] args)
        {
            ConcreteCompany root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));
            root.Add(new FinanceDepartment("总公司财务部"));

            ConcreteCompany comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源部"));
            comp.Add(new FinanceDepartment("华东分公司财务部"));
            root.Add(comp);

            ConcreteCompany comp1 = new ConcreteCompany("南京办事处");
            comp1.Add(new HRDepartment("南京办事处人力资源部"));
            comp1.Add(new FinanceDepartment("南京办事处财务部"));
            comp.Add(comp1);

            ConcreteCompany comp2 = new ConcreteCompany("杭州办事处");
            comp2.Add(new HRDepartment("杭州办事处人力资源部"));
            comp2.Add(new FinanceDepartment("杭州办事处财务部"));
            comp.Add(comp2);

            Console.WriteLine("\n结构图:");
            root.Display(1);
            Console.WriteLine("\n职责:");
            root.LineOfDuty();
        }
    }
}
