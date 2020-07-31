using System;
using System.Collections.Generic;

//解释器模式: 给定一个语言, 定义它的文法的一种表示, 并定义一个解释器, 这个解释器使用该表示来解释语言中的句子
//他要解决的问题是: 如果一种特定类型的问题发生的频率足够高, 那么可能就值得将问题的各个实例表述为一个简单语言中的句子。这样就可以构建一个解释器，该解释器通过解释这些句子来解决该问题
namespace 解释器模式
{
    //AbstractExpression 抽象表达式, 表明一个抽象的解释操作, 这个接口为抽象语法树中所有节点所共享
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
    //Context 包含解释器之外的一些全局信息
    class Context 
    {
        private string input;
        public string Input { get => input; set => input = value; }
        private string output;
        public string Output { get => output; set => output = value; }
    }
    //终结符表达式 
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }
    //非终结表达式
    class NonterminalExpression : AbstractExpression 
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }

    class Program
    {
        //客户端代码 构建表示该文法定义的语言中一个特定的句子的抽象语法树。调用解释操作
        static void Main(string[] args)
        {
            Context context = new Context();
            List<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            foreach (var item in list)
            {
                item.Interpret(context);
            }
        }
    }
}
