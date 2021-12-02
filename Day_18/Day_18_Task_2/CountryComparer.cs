using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Day_18_Task_2
{
    class CountryComparer : IEqualityComparer<Country>
    {
        public bool Equals( Country x,  Country y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode( Country obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
