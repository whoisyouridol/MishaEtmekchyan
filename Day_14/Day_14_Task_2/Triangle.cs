using System;
using System.Collections.Generic;
using System.Text;

namespace Day_14_Task_2
{
    class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            if (a == 0 || b == 0 || c == 0
                || a + b < c || c + b < a || a + c < b)
                throw new Exception("Triangle with these sides cannot exist!");

            A = a;
            B = b;
            C = c;
        }

        public double CountPerimeter()
        {
            return A + B + C;
        }
        public double CountArea()
        {
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public static bool operator ==(Triangle tr1, Triangle tr2)
        {
            return tr1.CountArea() == tr2.CountArea();
        }
        public static bool operator !=(Triangle tr1, Triangle tr2)
        {
            return tr1.CountArea() != tr2.CountArea();
        }


        public static bool operator >(Triangle tr1, Triangle tr2)
        {
            return tr1.CountArea() > tr2.CountArea();
        }
        public static bool operator <(Triangle tr1, Triangle tr2)
        {
            return tr1.CountArea() < tr2.CountArea();
        }

        public static Triangle operator +(Triangle tr1, Triangle tr2)
        {
            var area = tr1.CountArea() + tr2.CountArea();
            var a = Math.Sqrt(area * 2);
            var c = a * Math.Sqrt(2);
            return new Triangle(a, a, c);
        }
        public static explicit operator Triangle(double d)
        {
            return new Triangle(d,d,d);
        }
    }
}
