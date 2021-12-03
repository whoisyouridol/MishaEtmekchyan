using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_18_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\Admin Admin\Downloads\Cities_Practice_2.txt";
            var cities = City.GetCitiesFromFile(path);

            Console.WriteLine("1. Search Country 2. Search City");
            string choice = Console.ReadLine();
         
            if (choice == "1")
            {
                var countries = Country.GetCountriesFromFile(path, cities);

                Console.WriteLine("Input country`s name : ");
                string name = Console.ReadLine();
                foreach (var country in countries)
                {
                    if (name == country.Name)
                        Console.WriteLine(country.ToString());
                }

            }
            if (choice == "2")
            {
                Console.WriteLine("Input city`s name : ");
                string name = Console.ReadLine();

                Console.WriteLine(City.FindCity(cities, name).ToString());
            }
                
            
        }
    }
}
