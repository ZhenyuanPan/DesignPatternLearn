using System;
using System.Linq;
using System.Numerics;

namespace 状态模式_加班案例
{
    //工作类
    public class Work
    {
        private State current;
        //工作初始化为上午工作状态，既上午9点开始上班
        public Work()
        {
            current = new ForenoonState();
        }

        //钟点属性 , 状态转换的依据
        private double hour;
        public double Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        //"任务完成"属性, 是否能下班的依据
        private bool finish = false;
        public bool TaskFinished
        {
            get { return finish; }
            set { finish = value; }
        }

        public void SetState(State s)
        {
            current = s;
        }

        public void WirteProgram()
        {
            current.WriteProgram(this);
        }

    }

    //抽象状态
    public abstract class State
    {
        public abstract void WriteProgram(Work w);
    }

    #region 上午和中午工作状态

    //上午工作状态
    public class ForenoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 12)
            {
                Console.WriteLine("当前时间: {0}点 上午工作,精神百倍", w.Hour);
            }
            else
            {
                w.SetState(new NoonState());
                w.WirteProgram();
            }
        }
    }

    //中午工作状态
    public class NoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour<13)
            {
                Console.WriteLine("当前时间: {0}点 饿了, 午饭; 犯困, 午休。",w.Hour);
            }
            else 
            {
                w.SetState(new AfternoonState());
                w.WirteProgram();
            }
        }
    }
    #endregion

    #region 下午和傍晚工作状态类
    //下午工作状态
    public class AfternoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour <17)
            {
                Console.WriteLine("当前时间: {0} 点 下午状态还不错，继续努力",w.Hour);
            }
            else 
            {
                w.SetState(new EveningState());
                w.WirteProgram();
            }
        }
    }

    //晚间工作状态
    public class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            //如果完成任务则转入下班状态
            if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WirteProgram();
            }
            else 
            {
                if (w.Hour < 21)
                {
                    Console.WriteLine("当前时间: {0}点 加班哦, 疲惫至极", w.Hour);
                }
                else 
                {
                    w.SetState(new SleepingState());
                    w.WirteProgram();
                }
            }
        }
    }
    #endregion

    #region 睡眠状态和下班休息状态类

    //下班休息状态
    public class RestState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间:{0}点 下班回家了",w.Hour);
        }
    }

    //睡眠状态
    public class SleepingState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine("当前时间:{0}点 困得不行了, 睡觉了。", w.Hour);
        }
    }

    #endregion


    class Program
    {
        static void Main(string[] args)
        {
            //紧急项目
            Work[] emergencyProject = new Work[] {
                new Work() { Hour = 9}, 
                new Work() { Hour = 16},
                new Work() { Hour = 20,TaskFinished = true},
                new Work() { Hour = 20,TaskFinished = false},
                new Work() { Hour = 22,TaskFinished = false}
            };

            emergencyProject.ToList().ForEach(e => e.WirteProgram());

        }
    }
}
