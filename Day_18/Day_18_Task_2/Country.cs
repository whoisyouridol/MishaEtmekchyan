using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day_18_Task_2
{
    public class Country : GeographicEntity
    {
        private List<City> _cities = new List<City>();

        public List<City> Cities
        {
            get { return _cities; }
            set { _cities = value; }
        }

        public Country(List<City> cities,string name)
        {
            Name = name;

            foreach (var city in cities)
            {
                if (city.CountryName == name)
                {
                    Area += city.Area;
                    Population += city.Population;

                    Cities.Add(city);
                }
            }
        }

        public static List<Country> GetCountriesFromFile(string path, List<City> cities)
        {
            var result = new List<Country>();
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadLine();

                while (!string.IsNullOrEmpty(str))
                {
                    var temp = str.Split('|').Last();
                    var country = new Country(cities,temp);
                    str = sr.ReadLine();

                    result.Add(country);
                }
            }
            result = result.Distinct(new CountryComparer()).ToList();

            _checkCapitals(result);

            return result;
        }

        private static void _checkCapitals(List<Country> countries)
        {
            try
            {
                int counter = 0;
                foreach (var item in countries)
                {
                    foreach (var city in item.Cities)
                    {
                        if (city.IsCapital)
                        {
                            counter++;
                        }
                    }
                }
                if (counter > 1)
                {
                    throw new CountryMustHaveSingleCapital("Here can be just 1 Capital!");
                }
            }
            catch (CountryMustHaveSingleCapital ex)
            {
                const string path = @"C:\Users\Admin Admin\Downloads\Log.txt";

                using StreamReader sr = new StreamReader(path);
                using StreamWriter sw = new StreamWriter(path);
                string old = sr.ReadToEnd();
                sw.WriteLine(old + " " + ex.Message);
            }
            
        }
        private string _printCities()
        {
            var result = "";
            foreach (var item in Cities)
            {
                if (!item.IsCapital)
                {
                    result = result + item.Name + " ";

                }
                else 
                    result = result  + item.Name + "  (is capital) ";
            }
            return result;
        }
        public override string ToString()
        {
           
                return $"Name {Name}, area : {Area}, population : {Population}, Cities : {_printCities()} ";

        }
    }
}
