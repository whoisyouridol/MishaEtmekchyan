using System;

namespace Day_04_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size : ");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            var arr = new int[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                Console.Write("Enter number for index " + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }


            for (int i = 0; i < arrSize; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
