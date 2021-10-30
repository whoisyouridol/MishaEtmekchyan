using System;
namespace Day_04_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array row size : ");
            int rowSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter array column size : ");
            int columnSize = Convert.ToInt32(Console.ReadLine());
            var arr = new int[rowSize, columnSize];
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + " : ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (j == columnSize - 1)
                    {
                        Console.Write(arr[i, j]);

                    }
                    else
                        Console.Write(arr[i, j] + ", ");
                }
                Console.WriteLine();
            }

        }
    }
}