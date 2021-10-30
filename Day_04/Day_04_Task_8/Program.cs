using System;

namespace Day_04_Task_8
{
    class Program
    {

        static void Main()
        {
            var arr = new int[8, 8];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i + j > 2 * i)
                    {
                        arr[i, j] = 1;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 7)
                        Console.Write(arr[i, j]);
                    else
                        Console.Write(arr[i, j] + " , ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("______________________________ ");

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                   // ?????????????????
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 7)
                        Console.Write(arr[i, j]);
                    else
                        Console.Write(arr[i, j] + " , ");
                }
                Console.WriteLine();
            }
        }

    }
}