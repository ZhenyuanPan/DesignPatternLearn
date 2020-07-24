using System;

namespace 模板方法模式_抄题写答案
{
    //考试试卷
    class TestPaper 
    {
        public void TestQuestion_1() 
        {
            Console.WriteLine("1+1=? 答案:"+ Answer_1());
        }
        public virtual string Answer_1() 
        {
            return "";
        } 
        public void TestQuestion_2() 
        {
            Console.WriteLine("1*1=? 答案:"+ Answer_2());
        }
        public virtual string Answer_2() 
        {
            return "";
        }
    }

    //学生A抄的试卷, 子类就非常简单了，重写虚方法后,把答案填上, 其他什么都不用管。因为父类建立了所有重复的模板。
    class TestPaperA : TestPaper 
    {
        public override string Answer_1()
        {
            return "2";
        }
        public override string Answer_2()
        {
            return "1";
        }
    }

    class TestPaperB : TestPaper
    {
        public override string Answer_1()
        {
            return "空";
        }
        public override string Answer_2()
        {
            return "空";
        }
    }
    class Program
    {
        //客户端代码 
        static void Main(string[] args)
        {
            #region MyRegion
            //TestPaperA stuA = new TestPaperA();
            //stuA.TestQuestion_1();
            //stuA.TestQuestion_2(); 
            #endregion

            #region 将子类变量的声明改成了父类，利用了多态性。实现了代码的复用1
            TestPaper stuA = new TestPaperA();
            TestPaper stuB = new TestPaperB();
            stuA.TestQuestion_1();
            stuA.TestQuestion_2();


            #endregion
        }
    }
}
