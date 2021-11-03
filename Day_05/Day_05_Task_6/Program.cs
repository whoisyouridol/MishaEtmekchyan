using System;

namespace Day_05_Task_6
{
    class Program
    {
        static char[] FillArray(int arraySize)
        {
            var array = new char[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write("Enter integer for index " + i + " :  ");
                array[i] = Convert.ToChar(Console.ReadLine());
            }
            return array;
        }

        static int CountElementsInArray(char[] array,char element)
        {
            var counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    counter++;
                }
            }
            return counter;
        }


        static void PrintValue(char element, int amount)
        {
            Console.WriteLine("'" + element + "' shegvxda " + amount + "-jer" );
        }
        static void Main(string[] args)
        {
            Console.Write("Enter size of array : ");
            int size = Convert.ToInt32(Console.ReadLine());
            var array = FillArray(size);

            char character = 'a';
            var amount = CountElementsInArray(array, character);
            PrintValue(character, amount);

        }
    }
}
