using System;

namespace Day_05_Task_8
{
    class Program
    {
        static int InputNumber()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        static string DecomposeNumber(int num)
        {
            string result = "";
            int power = 0;
            while (num > 0)
            {
                int digit = num % 10;
                if (num < 10)
                    result += digit + " * " + "10^" + power;
                else
                    result += digit + " * " + "10^" + power + " + ";
                num /= 10;
                power++;
            }
            return result;
        }
        static void Main(string[] args)
        {
            var number = InputNumber();
            Console.WriteLine(DecomposeNumber(number));
        }
    }
}
