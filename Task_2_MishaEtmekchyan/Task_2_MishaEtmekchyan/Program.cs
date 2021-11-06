using System;

namespace Task_2_MishaEtmekchyan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input array size : ");
            int size = Convert.ToInt32(Console.ReadLine());
            var arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Write " + (i + 1) +  " element : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            // me-2 ver davwere : (
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
          
        }
    }
}
