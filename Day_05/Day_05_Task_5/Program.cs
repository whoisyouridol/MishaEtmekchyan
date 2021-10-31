using System;

namespace Day_05_Task_5
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
        static int CountFactorial(int [] arr, int number)
        {
            int factorial = 1;
            bool NumberIsInArray = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    NumberIsInArray = true;
                    while (number > 0)
                    {
                        factorial *= number;
                        number--;
                    }
                }
            }
            if (NumberIsInArray)
            {
                return factorial;
            }
            else return 0;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of array : ");
            int size = Convert.ToInt32(Console.ReadLine());
            var array = FillArray(size);

            int number = 5;
            var result = CountFactorial(array, number);

            if (result == 0)
                Console.WriteLine("Number " + number + " was not found in the given array");
            else
                Console.WriteLine("Factorial of " + number + " is " + result);
        }
    }
}
