using System;
using System.Collections.Generic;

namespace 享元模式_内部状态与外部状态
{
    //用户类 用于网赚的客户账号, 是"网站"类的外部状态
    public class User 
    {
        private string name;
        public User(string name) 
        {
            this.name = name;
        }
        public string Name { get => name; }
    }

    //网站抽象类
    abstract class WebSite 
    {
        public abstract void Use(User user);
    }

    //具体网站类
    class ConcreteWebSite : WebSite 
    {
        private string name = "";
        public ConcreteWebSite(string name) { this.name = name; }
        public override void Use(User user)
        {
            Console.WriteLine("网站分类:"+ name + "用户:"+user.Name);
        }
    }

    //网站工厂类
    class WebSiteFactory 
    {
        private Dictionary<string, WebSite> flyweights = new Dictionary<string, WebSite>();

        //获得网站分类
        public WebSite GetWebSiteCategory(string key) 
        {
            if (!flyweights.ContainsKey(key))
            {
                flyweights.Add(key, new ConcreteWebSite(key));
            }
            return flyweights[key];
        }

        //获取网站分类总数
        public int GetWebSiteCount() 
        {
            return flyweights.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();
            WebSite fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("小菜"));
            WebSite fy = f.GetWebSiteCategory("产品展示");
            fy.Use(new User("大鸟"));
            WebSite fz = f.GetWebSiteCategory("博客");
            fz.Use(new User("迪迪"));

            Console.WriteLine("得到的网站分类总数为{0}",f.GetWebSiteCount());
        }
    }
}
