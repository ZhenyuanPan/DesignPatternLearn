using System;

namespace 责任链模式_加薪非要老总批
{
    //申请
    class Request 
    {
        //申请类别
        private string requestType;
        public string RequestType { get => requestType; set => requestType = value; }

        //申请内容
        private string requestContent;
        public string RequestContent { get => requestContent; set => requestContent = value; }

        //数量
        private int number;
        public int Number { get => number; set => number = value; }

    }


    //管理者
    abstract class Manager 
    {
        protected string name;
        public Manager(string name)
        {
            this.name = name;
        }
        //管理者的上级
        protected Manager superior;
        //设置管理者的上级
        public void SetSuperior(Manager superior) 
        {
            this.superior = superior;
        }
        //申请请求
        abstract public void RequestApplications(Request request);
    }

    //经理
    class CommonManager : Manager 
    {
        public CommonManager(string name): base(name) 
        {
            
        }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准", name, request.RequestContent, request.Number);
            }
            else 
            {
                if (superior != null)
                {
                    //其余的申请都需要转到上级
                    superior.RequestApplications(request);
                }
            }
        }
    }

    //总监
    class Majordomo : Manager
    {
        public Majordomo(string name) : base(name) { }
        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 5)
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准", name, request.RequestContent, request.Number);
            }
            else
            {
                if (superior != null)
                {
                    //其余的申请都需要转到上级
                    superior.RequestApplications(request);
                }
            }
        }
    }

    //总经理 总经理的权限就是全部都需要处理
    class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name) { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "请假" )
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number<=500)
            {
                Console.WriteLine("{0}:{1} 数量{2} 被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number > 500)
            {
                Console.WriteLine("{0}:{1} 数量{2} 再说吧", name, request.RequestContent, request.Number);
            }
        }
    }


    class Program
    {
        //还有一个关键是客户端如何编写
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("经理");
            Majordomo zongjian = new Majordomo("总监");
            GeneralManager zongjingli = new GeneralManager("总经理");

            //设置上级, 完全可以根据实际需求来更改设置
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zongjingli);


            Request request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "小菜请假";
            request.Number = 1;
            //客户端的申请都是由'经理'发起, 但是实际谁来决策由具体的管理类来处理, 客户端不知道
            jinli.RequestApplications(request);

            Request request1 = new Request();
            request1.RequestType = "请假";
            request1.RequestContent = "小菜请假";
            request1.Number = 4;
            jinli.RequestApplications(request1);

            Request request2 = new Request();
            request2.RequestType = "加薪";
            request2.RequestContent = "小菜请求加薪";
            request2.Number = 500;
            jinli.RequestApplications(request2);

            Request request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "小菜请求加薪";
            request3.Number = 1500;
            jinli.RequestApplications(request3);

        }
    }
}
