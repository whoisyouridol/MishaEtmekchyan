using System;

namespace Day_04_Task_7
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
            var arr2 = new int[rowSize, columnSize];

            Console.WriteLine("Fill first matrix : ");
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + " : ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Fill second matrix : ");
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + " : ");
                    arr2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }




            Console.WriteLine("Here is sum of two matrices");
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    if (j == columnSize - 1)
                    {
                        Console.Write(arr[i, j] + arr2[i,j]);

                    }
                    else
                        Console.Write(arr[i, j] + arr2[i,j] + ", ");
                }
                Console.WriteLine();
            }

        }
    }
}
