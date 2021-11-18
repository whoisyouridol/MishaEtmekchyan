using Day_12_Task_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Day_12_Task_1_With_Interfaces
{
    class Triangle : IMeasurable
    {
      

        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();


        }

        public  double Area()
        {
            var semiperimeter = (Point.CountLength(A,B) + Point.CountLength(B,C) + Point.CountLength(A,C))/ 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - Point.CountLength(A, B)) * (semiperimeter - Point.CountLength(B, C)) * (semiperimeter - Point.CountLength(A, C)));
        }

        public double Perimeter()
        {
            return Point.CountLength(A, B) + Point.CountLength(B, C) + Point.CountLength(A, C);
        }
    }
}
