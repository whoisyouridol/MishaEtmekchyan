using System;

namespace Day_05_Task_1
{
    class Program
    {
        static int GetElementByIndex(int [] arr, int index)
        {
            int output = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == index)
                    output = arr[i];
            }
            return output;
        }
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 6, 1, 7, 3, 7, 23, 6, 22, 77, 42 };
            int index = 6;
            Console.WriteLine("Number at index " + index + " in the array is " + GetElementByIndex(arr, index));

        }
    }
}
