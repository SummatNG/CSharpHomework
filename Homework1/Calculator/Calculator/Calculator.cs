using System;
namespace Calculator
{


    public class Calculator
    {
        public double GetResult(string symbol, double num1, double num2)
        {
            double result = 0;
            if (symbol == "+")
                result = num1 + num2;
            else if (symbol == "-")
                result = num1 - num2;
            else if (symbol == "*")
                result = num1 * num2;
            else if (symbol == "/")
                result = num1 / num2;
            else
                Console.WriteLine("请重新输入");
            return result;

        }

    }

}