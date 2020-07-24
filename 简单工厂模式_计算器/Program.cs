using System;

namespace 简单工厂模式_计算器
{

    abstract class  Operation 
    {
        public float numA;
        public float numB;
        public abstract float GetResult();
    }

    class OperationAdd : Operation
    {
        public override float GetResult()
        {
            return numA + numB;
        }
    }

    class OperationSub : Operation
    {
        public override float GetResult()
        {
            return numA - numB;
        }
    }

    class OprationFactory
    {
        public static Operation CreateOperation(string operation) 
        {
            Operation oper = null;
            switch (operation)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                default:
                    break;
            }
            return oper;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Operation oper;
            oper = OprationFactory.CreateOperation("+");
            oper.numA = 10;
            oper.numB = 100;
            Console.WriteLine(oper.GetResult());
               
        }
    }
}
