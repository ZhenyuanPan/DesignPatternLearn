using System;

namespace 原型模式_加入深复制__发简历
{
    class WorkExperience : ICloneable
    {
        private string workDate;
        public string WorkDate { get => workDate; set => workDate = value; }

        private string company;
        public string Company { get => company; set => company = value; }

        //string类型是特殊的引用类型，和值类型一样clone对象  
        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }

    class Resume : ICloneable
    {
        private string name;
        private string sex;
        private string age;
        private WorkExperience work;

        public Resume(string name) 
        {
            this.name = name;
            work = new WorkExperience();
        }

        private Resume(WorkExperience work) 
        {
            //包装了一层 深拷贝了WorkExperience引用类型
            this.work = (WorkExperience)work.Clone();
        }

        public void SetPersonalInfo(string sex,string age)
        {
            this.sex = sex;
            this.age = age;
        }

        public void SetWorkExperience(string workDate,string company) 
        {
            work.WorkDate = workDate;
            work.Company = company;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}",name,sex,age);
            Console.WriteLine("工作经历:{0} {1}",work.WorkDate,work.Company);
        }


        public object Clone()
        {
            Resume obj = new Resume(this.work);
            obj.name = this.name;
            obj.sex = this.sex;
            obj.age = this.age;
            return obj;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男","29");
            a.SetWorkExperience("1998-2000","xx公司");
            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("1998-2006","yy企业");
            Resume c = (Resume)a.Clone();
            c.SetPersonalInfo("男", "24");
            c.SetWorkExperience("1998-2003","zz公司");

            a.Display();
            b.Display();
            c.Display();
        }
    }
}
