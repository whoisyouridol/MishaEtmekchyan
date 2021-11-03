using System;

namespace Day_05_Task_4
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
        static double CountAvg(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return Math.Round(Convert.ToDouble(sum)/ array.Length,2);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of array : ");
            int size = Convert.ToInt32(Console.ReadLine());
            var array = FillArray(size);
            //var arr = new int[] {6,2,3,2,12,1 };

            Console.WriteLine(CountAvg(array));

        }
    }
}
