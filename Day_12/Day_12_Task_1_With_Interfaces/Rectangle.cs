using Day_12_Task_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1_With_Interfaces
{
    class Rectangle : IMeasurable
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public Rectangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
            D = new Point();

        }
        public double Area()
        {
            return Point.CountLength(A, B) * Point.CountLength(B, C);
        }

        public double Perimeter()
        {
            return (Point.CountLength(A, B) + Point.CountLength(B,C) ) * 2;
        }
    }
}
