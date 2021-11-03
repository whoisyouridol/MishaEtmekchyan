using System;

namespace Day_06_Task_1
{
    class Program
    {

        static string GetVowels(string str)
        {
            string result = "";
            string str2 = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                if (str2[i] == 'A' || str2[i] == 'O' || str2[i] == 'I' || str2[i] == 'U' || str2[i] == 'Y' || str2[i] == 'E')
                {
                    result += str[i] + " ";
                }
            }
            return result;
        }

        static string GetConsonants(string str)
        {
            string result = "";
            string str2 = str.ToUpper();
            for (int i = 0; i < str.Length; i++)
            {

                if (str2[i] > 'A' && str2[i] <= 'Z'
                   && str2[i] != 'A' && str2[i] != 'O' && str2[i] != 'I' && str2[i] != 'U' && str2[i] != 'Y' && str2[i] != 'E')
                {
                    result += str[i] + " ";

                }
            }
            return result;
        }
        static void Main(string[] args)
        {

            Console.WriteLine(GetVowels("Hello World!"));
            Console.WriteLine(GetConsonants("Hello world!"));



        }
    }
}
