using System;
using System.Dynamic;

namespace 策略模式
{
    abstract class Strategy 
    {
        public abstract void AlgorithmInterface();
    }
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法A实现");
        }
    }
    class CocreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法B实现");
        }
    }
    class Context 
    {
        Strategy strategy;
        public Context(Strategy strategy) 
        {
            this.strategy = strategy;
        }
        //上下文接口
        public void ContextInterface() 
        {
            strategy.AlgorithmInterface();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStrategyA());
            context.ContextInterface();
        }
    }
}
