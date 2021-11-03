using System;

namespace Day_05_Task_2
{
    class Program
    {
        static int GetSumOfDigitsByIndex(int [] arr, int index)
        {
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == index)
                {
                    while (arr[i] > 0)
                    {
                        result += arr[i] % 10;
                        arr[i] /= 10;
                    }
                    return result;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            var array = new int[] {1,64,12,88,22,763,242 };

            int index = 6;
            Console.WriteLine("The sum of the digits of a number at index " 
                + index + " is " + GetSumOfDigitsByIndex(array,index));


        }
    }
}
