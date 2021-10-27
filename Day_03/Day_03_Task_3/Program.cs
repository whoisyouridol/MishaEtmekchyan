using System;

namespace Day_03_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i + " cubed is " + i * i * i);
                // an asec sheidzleba : Console.WriteLine(i + " cubed is " + Math.Pow(i,3));
            }
        }
    }
}
