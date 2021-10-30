﻿using System;

namespace Day_04_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size : ");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            var arr = new int[arrSize];
            int product = 1;
            for (int i = 0; i < arrSize; i++)
            {
                Console.Write("Enter number for index " + i + ": ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
                product *= arr[i];
            }
            Console.WriteLine("Product of array elements is : " + product);
        }
    }
}
