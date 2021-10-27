using System;

namespace Day_03_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 1)
                    sum += i;
            }
            Console.WriteLine("Sum of odd numbers from 1 to " + number + " is " + sum);
        }
    }
}
