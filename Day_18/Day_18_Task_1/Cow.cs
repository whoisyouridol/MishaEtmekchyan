using System;
using System.Collections.Generic;
using System.Text;

namespace Day_18_Task_1
{
    public class Cow
    {
        public Cow(int d, string n)
        {
            DaysOflife = d;
            Name = n;
        }
        public int DaysOflife { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Day: {DaysOflife}, Name: {Name}";
        }

        public IEnumerable<string> Colour
        {
            get
            {
                yield return "brown";
                yield return "black";
                yield return "white";
            }
        }
    }
}
