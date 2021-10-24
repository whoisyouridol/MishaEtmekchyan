using System;

namespace Day_02_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //დაწერეთ კონსოლ აპლიკაცია სადაც მომხმარებელს ექნება საშუალება შეიტანოს მთელი
            //რიცხვი, პროგრამამ უნდა გაარკვიოს ეს რიცხვი ლუწია თუ კენტი და იმის მიხედვით
            //დაბეჭდოს შესაბამისი შეტყობინება.
            Console.WriteLine("Enter integer number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number %2 == 0)     
                Console.WriteLine("Entered number " + number + " is prime");
           
            else
                Console.WriteLine("Entered number " + number + " is odd");

        }
}
}
