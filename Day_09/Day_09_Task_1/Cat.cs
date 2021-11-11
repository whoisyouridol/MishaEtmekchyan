using System;
using System.Collections.Generic;
using System.Text;

namespace Day_09_Task_1
{
    class Cat
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        private const int massStandart = 10;
        public void Meow(int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Meowww....");
            }
        }
        public void Eat(int mass)
        {
            Console.WriteLine($"{Name} start eating.");
            while (mass >= 1)
            {
                Console.WriteLine("Eating ....");
                mass -= massStandart;
            }
            
            Console.WriteLine($"{Name} finished eating.");
        }
    }
}