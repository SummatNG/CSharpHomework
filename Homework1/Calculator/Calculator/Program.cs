using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("请输入要计算的类型:");
            string type = Convert.ToString(Console.ReadLine());
            Console.WriteLine("请输入第一个运算数:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入第二个运算数:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double result = calculator.GetResult(type,num1,num2);
            Console.WriteLine("计算结果为:" + result);
        }

    }
}
