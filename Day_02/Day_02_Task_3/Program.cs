using System;

namespace Day_02_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //დაწერეთ კონსოლ აპლიკაცია სადაც მომხმარებელს ექნება საშუალება შეიტანოს
            //რიცხვი, ხოლო პროგრამა დაბეჭდავს მის კვადრატულ ხარისხსს.(მოიძიეთ გუგლში
            //ფუნქცია რითი შეიძლება რიცხვის ახარისხება)
            Console.WriteLine("Enter number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The Pow of entered number is : " + Math.Pow(number,2));
        }
    }
}
