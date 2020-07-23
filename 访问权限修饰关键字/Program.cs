using System;

namespace 访问权限修饰关键字
{
    public abstract class A
    {
        public string strPublic = "public";
        private string strPrivate = "private";
        protected string strProtected = "protected";

        public string StrPrivate { get => strPrivate; set => strPrivate = value; }
        public string StrProtected { get => strProtected; set => strProtected = value; }

    }
    public class B : A
    {
        public void ExplainProtected()
        {
            Console.WriteLine(this.strProtected);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            B insB = new B();
            Console.WriteLine(insB.strPublic);
            Console.WriteLine(insB.StrPrivate);
            Console.WriteLine(insB.StrProtected);
            Console.WriteLine("--------------继承: 子类继承父类的所有成员，并且保留父类成员的访问修饰符（保留父类修饰权限）---------------------------------------");
            Console.WriteLine("--------------私有：不能在其他类中访问insB的私有成员，----------------");
            Console.WriteLine("--------------保护：不能在除了子类以外的其他类中访问insB的保护成员，----------------");
            #region protected 与 private 均不能在 Program 类中访问
            //Console.WriteLine(insB.strPrivate);
            //Console.WriteLine(insB.strProtected);
            #endregion

        }
    }
}
