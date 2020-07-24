using System;

namespace 原型模式_发简历
{
    class Resume : ICloneable
    {
        private string name;
        private string sex;
        private string age;
        private string timeArea;
        private string company;

        public Resume(string name)
        {
            this.name = name;
        }

        //设置个人信息
        public void SetPersonalInfo(string sex,string age)
        {
            this.sex = sex;
            this.age = age;
        }

        //设置工作经历
        public void SetWorkExperience(string timeArea,string company) 
        {
            this.timeArea = timeArea;
            this.company = company;
        }

        //显示
        public void Display() 
        {
            Console.WriteLine("{0}{1}{2}",name,sex,age);
            Console.WriteLine("工作经历:{0} {1}",timeArea,company);
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }

    class Program
    {
        /*
            注意string是一种拥有值类型特点的特殊引用类型，MemberwiseClone（）方法是这样的，如果子弹是值类型的
            则对该字段执行逐位复制, 如果字段是引用类型的, 则复制引用但不复制引用的对象; 因此,原始对象及其副本引用同一对象
         */

        //客户端代码
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男","29");
            a.SetWorkExperience("1998-2000","xx公司");

            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("1996-2006", "yy公司");

            Resume c = (Resume)a.Clone();
            c.SetPersonalInfo("男","23");

            a.Display();
            b.Display();
            c.Display();
        }
    }
}
