using System;
using System.Collections.Generic;

namespace 设计模式
{
    class Program
    {
        public static List<Action<string>> actions = new List<Action<string>>();
        public static string str;
        static void Main(string[] args)
        {
            actions.Add((string a)=> { Console.WriteLine("Hello World!{0}",a); });
            actions.Add((string b) => { Console.WriteLine("This is new stuff!{0}",b); });
            actions.Add((str) => { Console.WriteLine("Holy Shit!"); });
            //遍历1
            actions.ForEach(action => action.Invoke(str));
            //遍历2
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Invoke(str);
            }
            //遍历3
            foreach (var item in actions)
            {
                item.Invoke(str);
            }
        }
    }
}
