using System;

namespace Day_03_Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of rows in Floyd`s triangle to be printed : ");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if ((j % 2 == 0) == (i %2 == 0))
                    {
                        Console.Write("1");
                    }
                    else
                        Console.Write("0");
                }
                Console.WriteLine();
            }
        }
    }
}
