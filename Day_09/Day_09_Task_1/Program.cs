using System;

namespace Day_09_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter, what you want to do");
            string command = Console.ReadLine();
            if (command.ToLower() == "create cat object")
            {
                var cat = new Cat();
                Console.WriteLine("Creating Cat object...");

                Console.Write("Enter name : ");
                cat.Name = Console.ReadLine();

                Console.Write("Enter breed : ");
                cat.Breed = Console.ReadLine();

                Console.Write("Enter sex : ");
                cat.Gender = Console.ReadLine();

                Console.Write("Enter food weight in grams : ");
                int mass = Convert.ToInt32(Console.ReadLine());
                cat.Eat(mass);


                Console.Write("Enter meowing count : ");
                int counter = Convert.ToInt32(Console.ReadLine());
                cat.Meow(counter);
            }
        }
    }
}
