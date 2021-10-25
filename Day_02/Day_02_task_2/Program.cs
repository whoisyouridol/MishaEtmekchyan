using System;

namespace Day_02_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //დაწერეთ კონსოლ აპლიკაცია სადაც მომხმარებელს ექნება საშუალება შეიტანოს სამი რიცხვი
            //მორიგეობით, პროგრამა კი დაუბეჭდავს შემოტანილი პარამეტრების გათვალისწინებით
            //შესაძლებელია თუ არა ეს სამი რიცხვი იყოს სამკუთხედის გვერდები.
            Console.WriteLine("Enter first number : ");
            uint side1 = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Enter second number : ");
            uint side2 = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Enter third number : ");
            uint side3 = Convert.ToUInt32(Console.ReadLine());

            

            if (((side1 + side2) < side3) ||
                ((side2 + side3) < side1) ||
                ((side1 + side3) < side2) || 
                side1 == 0 || side2 == 0 || side3 == 0)
            Console.WriteLine("This should not be a triangle!");
            
            else
                Console.WriteLine("This should be a triangle!");
         
        }
    }
}
