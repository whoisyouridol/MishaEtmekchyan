using System;

namespace Day_04_Task_5
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
            Console.WriteLine("Unique elements of array are : ");
            for (int i = 0; i < arrSize; i++)
            {
                bool isUnique = true;
                for (int j = 0; j < arrSize; j++)
                {
                    if (arr[i] == arr[j] && i !=j)
                    {
                        isUnique = false;
                    }
                }
                if (isUnique)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}
