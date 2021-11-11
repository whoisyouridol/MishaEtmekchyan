using System;
using System.Collections.Generic;
using System.Text;

namespace Day_09_Task_2
{
    class Triangle
    {
        private int _Side1;
        public int Side1
        {
            get { return _Side1; }
            set { _Side1 = value;}
        }

        private int _Side2;
        public int Side2
        {
            get { return _Side2; }
            set { _Side2 = value; }

        }

        private int _Side3;
        public int Side3
        {
            get { return _Side3; }
            set { _Side3 = value; }
        }

        public bool IsTriangle()
        {
            if ((_Side1 == 0 || _Side2 == 0 || _Side3 == 0) 
                || _Side1 + _Side2 < _Side3 || _Side3 + _Side2 < _Side1 || _Side1 + _Side3 < _Side2)
                return false;

            else return true;
        }
        public int CountPerimeter()
        {
            return _Side1 + _Side2 + _Side3;
        }
        public double CountArea()
        {
            double s = (_Side1 + _Side2 + _Side3) / 2;
            return Math.Sqrt(s * (s - _Side1) * (s - _Side2) * (s - _Side3));
        }


    }
}
