using System;
namespace Day_02_Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth year : ");
            int year = Convert.ToInt32(Console.ReadLine());

            var tempYear = year;
            while (tempYear - 12 >= 1948)
            {
                tempYear -= 12;
            }

            var result = tempYear switch
            {
                1948 => "Rat",
                1949 => "Ox",
                1950 => "Tiger",
                1951 => "Rabbit",
                1952 => "Dragon",
                1953 => "Snake",
                1954 => "Horse",
                1955 => "Goat",
                1956 => "Monkey",
                1957 => "Rooster",
                1958 => "Dog",
                1959 => "Pig",
                _ => throw new NotImplementedException(),
            };
            Console.WriteLine(year + " was " + result + " year ");
        }
    }
}
