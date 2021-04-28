using System;

namespace GetValue
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int[] numbers = new int[9]{ 2, 4, 87, 45, 90, 24, 88, 66, 287 };
            Console.WriteLine("当前整数组的最大值为:");
            Console.WriteLine(GetMax(numbers));
            Console.WriteLine("当前整数组的最小值为:");
            Console.WriteLine(GetMin(numbers));
            Console.WriteLine("当前整数组的和为:");
            Console.WriteLine(GetSum(numbers));
            Console.WriteLine("当前整数组的平均值为:");
            Console.WriteLine(GetAvg(numbers));
        }

        public static int GetMax(int[] input)
        {
            int max = input[0];
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] > max)
                    max = input[i];
            }
            return max;
        }

        public static int GetMin(int[] input)
        {
            int min = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < min)
                    min = input[i];
            }
            return min;
        }



        public static int GetSum(int[] input)
        {
            int sum = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                sum = sum + input[i];
            }

            return sum;
        }

        public static double GetAvg(int[] input)
        {
            double avg = (double) GetSum(input) / input.Length;
            return avg;
        }
    }
}
