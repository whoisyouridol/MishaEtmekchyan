using System;

namespace Day_05_Task_3
{
    class Program
    {
        static int[] FillArray(int arraySize)
        {
            var array = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("Enter integer for index " + i + " :  ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            return array;
        }
        static int GetMaxElement(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
        static int GetMinElement(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                }
            }
            return min;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of array : ");
            int size = Convert.ToInt32(Console.ReadLine());
            var array = FillArray(size);
            Console.WriteLine("The minimum number in the array is : " + GetMinElement(array));
            Console.WriteLine("The maximum number in the array is : " + GetMaxElement(array));

        }
    }
}
