using System;

namespace Day_03_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum from 0 to 10 is " + sum);
        }
    }
}
