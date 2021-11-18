using Day_12_Task_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1_With_Interfaces
{
    class Circle : IMeasurable
    {
        public Point Center { get; set; }
        public Point A { get; set; }

        public Circle()
        {
            Center = new Point();
            A = new Point();
        }
        public double Area()
        {
            return Math.Pow(Point.CountLength(Center, A), 2) * Math.PI;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Point.CountLength(Center, A) ;
        }
    }
}
