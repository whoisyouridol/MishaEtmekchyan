using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Day_18_Task_2
{
    public class City : GeographicEntity
    {
        public bool IsCapital { get; set; }
        public string CountryName { get; set; }
        public City(string name,double area,int population,bool isCapital,string countryName)
        {
            Name = name;
            Area = area;
            Population = population;
            IsCapital = isCapital;
            CountryName = countryName;
        }
      
       public static List<City> GetCitiesFromFile(string path)
        {
            var result = new List<City>();
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadLine();

                while (!string.IsNullOrEmpty(str))
                {
                    var splited = str.Split('|');

                    if (!string.IsNullOrEmpty(str))
                    {
                        var city = new City(
                        splited[0],
                        double.Parse(splited[1].Replace(',', '.')),
                        int.Parse(splited[2]),
                        bool.Parse(splited[3]),
                        splited[4]
                        );

                        result.Add(city);
                    }
                    str = sr.ReadLine();
                    
                }
                
            }
            
            return result;
        }

        public static City FindCity(List<City> cities, string name)
        {
            foreach (var item in cities)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public override string ToString()
        {
            if (IsCapital)
            {
                return $"Name {Name}, area : {Area}, population : {Population}, country : {CountryName}, is capital ";

            }
            else return $"Name {Name}, area : {Area}, population : {Population}, country : {CountryName}"; 
        }
    }
}
