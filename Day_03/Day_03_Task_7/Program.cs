using System;

namespace Day_03_Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            int n1 = 0, n2 = 1;
            int counter = 0;
            while (number - 1 > counter)
            {
                var temp_n2 = n2;  
                n2 += n1;
                n1 = temp_n2;

                if (counter == number - 2)
                    Console.Write(n2);
                else
                    Console.Write(n2 + ", ");

                counter++;
            }
        }
    }
}