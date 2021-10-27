using System;

namespace Day_03_Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            string output = String.Empty;

            for (int i = 0; number > 0; i++)
            {
                output += (number % 2).ToString();
                number = number / 2;
            }
            for (int i = output.Length - 1; i >= 0; i--)
            {
                Console.Write(output[i]);
            }
        }
    }
}
