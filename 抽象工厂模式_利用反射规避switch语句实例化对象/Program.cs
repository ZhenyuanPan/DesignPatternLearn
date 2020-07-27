using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Reflection;

namespace 抽象工厂模式_利用反射规避switch语句实例化对象
{
    public interface IUser
    {
        void Show();
    }
    public class SqlserverUser : IUser
    {
        public void Show()
        {
            Console.WriteLine("SqlserverUser");
        }
        public static void Debug() 
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().DeclaringType.FullName);
        }
    }

    public class OrcleUser : IUser
    {
        public void Show()
        {
            Console.WriteLine("OrcleUser");
        }
    }

    public class DataAccess 
    {
        private static readonly string AssemblyName = "抽象工厂模式_利用反射规避switch语句实例化对象";
        private static readonly string db = "Sqlserver";

        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            DataAccess.CreateUser().Show();

            var type = typeof(OrcleUser);
            var ms = type.GetMethod("Show");
            ms.Invoke(System.Activator.CreateInstance(type),null);
        }
    }
}
