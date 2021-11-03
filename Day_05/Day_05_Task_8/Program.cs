using System;

namespace Day_05_Task_8
{
    class Program
    {
        static int InputNumber()
        {
            Console.Write("Please, input a whole positive number : ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num < 1)
                return 0;
            else return num;
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
