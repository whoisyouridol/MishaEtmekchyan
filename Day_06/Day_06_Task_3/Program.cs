using System;

namespace Day_06_Task_3
{
    class Program
    {
        static string AddSpaces(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                result += str[i] + " ";
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(AddSpaces("Hello World!"));
        }
    }
}
