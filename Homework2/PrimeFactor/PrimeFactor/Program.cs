using System;

namespace PrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数:");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] result = GetPrimeFactor(input);
            Console.WriteLine("该整数的质数因子有:");
            for (int i = 0;i < result.Length; i++)
            {
                Console.WriteLine(result[i] + " ");
            }

            
        }

        public static int[] GetPrimeFactor(int number)
        {
            if (number <= 1)
                return null;
            else
            {
                int[] primeFactors = new int[0];
                for (int factor = 2,i = 0; factor * factor <= number; factor++)
                {
                    while (number % factor == 0)
                    {
                        AddElements(primeFactors, i, factor);
                        i++;
                        number = number / factor;
                    }
                }
                return primeFactors;


            }
        }

        public static int[] AddElements(int[] originalArray, int index, int value)
        {
            if (index >= originalArray.Length)
            {
                index = originalArray.Length;
            }

            int[] newArray = new int[originalArray.Length + 1];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (index >= 0)
                {
                    if (i < index)
                    {
                        newArray[i] = originalArray[i];
                    }
                    else if (i == index)
                    {
                        newArray[i] = value;
                    }
                    else
                    {
                        newArray[i] = originalArray[i - 1];
                    }
                }
                    
            }
            return newArray;
        }
    }
}



 
