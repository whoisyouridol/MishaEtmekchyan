using System;

namespace Day_15_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var intMath = new IntMathOperation();
            var generic = new Generic<IntMathOperation>(intMath);
            Console.WriteLine(generic.Add(10, 15));
        }
    }
}
