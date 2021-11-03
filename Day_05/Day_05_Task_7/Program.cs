using System;

namespace Day_05_Task_7
{
    class Program
    {
        static int[,] FillMatrix(int rowSize,int columnSize)
        {
            var matrix = new int[rowSize, columnSize];
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < columnSize; j++)
                {
                    Console.Write("Enter number for index " + i + "," + j + " : ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return matrix;
        }
        static int[,] Sum2Matrices(int[,] matrix1, int [,] matrix2)
        {
            var output = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    output[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return output;
        }
        static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == arr.GetLength(1) - 1)
                    {
                        Console.Write(arr[i, j]);

                    }
                    else
                        Console.Write(arr[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter array row size : ");
            int rowSize = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter array column size : ");
            int columnSize = Convert.ToInt32(Console.ReadLine());

            var matrix1 = FillMatrix(rowSize,columnSize);
            Console.WriteLine("=========================================");
            var matrix2 = FillMatrix(rowSize, columnSize);


            var result = Sum2Matrices(matrix1, matrix2);
            Console.WriteLine("Here is sum of matrices");
            PrintMatrix(result);
        }
    }
}
