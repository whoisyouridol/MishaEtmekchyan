using System;

namespace Day_03_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : " );
            int number = Convert.ToInt32(Console.ReadLine());

            int sum = 0;
            for (int i = 0; i <= number; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum from 1 to " + number + " is " + sum);
        }
    }
}