using System;

namespace Day_05_Task_8
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int num = 1230;
            int power = 0;
            string result = "";
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
            Console.WriteLine(result);
        }
    }
}
