using System;

namespace Day_03_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Divisors of 36 are : ");
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0 && i < number)
                    Console.Write(i + ", ");

                if (i == number)
                    Console.Write(i);        
            }
        }
    }
}
