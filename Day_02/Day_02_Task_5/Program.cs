using System;

namespace Day_02_Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your day of birth : ");
            byte day = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Enter your month of birth : ");
            string month = Console.ReadLine().ToLower();
            string zodiac = "";

            if ((day >= 20 && day <= 31 && month == "january") ||
                (day <= 18 && day >= 1 && month == "february"))
            {
                zodiac = "Aquaris";
            }


            if ((day >= 19 && day <= 29 && month == "february") ||
               (day <= 20 && day >= 1 && month == "march"))
            {
                zodiac = "Pisces";
            }


            if ((day >= 21 && day <= 31 && month == "march") ||
                 (day <= 19 && day >= 1 && month == "april"))
            {
                zodiac = "Aries";
            }


            if ((day >= 20 && day <= 30 && month == "april") ||
                (day <= 20 && day >= 1 && month == "may"))
            {
                zodiac = "Taurus";
            }


            if ((day >= 21 && day <= 31 && month == "may") ||
                (day <= 21 && day >= 1 && month == "june"))
            {
                zodiac = "Gemini";
            }


            if ((day >= 22 && day <= 30 && month == "june") ||
              (day <= 22 && day >= 1 && month == "july"))
            {
                zodiac = "Cancer";
            }


            if ((day >= 23 && day <= 31 && month == "july") ||
             (day <= 22 && day >= 1 && month == "august"))
            {
                zodiac = "Leo";
            }


            if ((day >= 23 && day <= 31 && month == "august") ||
            (day <= 22 && day >= 1 && month == "september"))
            {
                zodiac = "Virgo";
            }


            if ((day >= 23 && day <= 30 && month == "september") ||
             (day <= 23 && day >= 1 && month == "october"))
            {
                zodiac = "Libra";
            }


            if ((day >= 24 && day <= 31 && month == "october") ||
            (day <= 21 && day >= 1 && month == "november"))
            {
                zodiac = "Scorpius";
            }


            if ((day >= 22 && day <= 30 && month == "november") ||
            (day <= 21 && day >= 1 && month == "december"))
            {
                zodiac = "Sagittarius";
            }


            if ((day >= 22 && day <= 31 && month == "december") ||
            (day <= 19 && day >= 1 && month == "january"))
            {
                zodiac = "Capricornus";
            }

            if ((day >= 22 && day <= 30 && month == "december") ||
            (day <= 19 && day >= 1 && month == "january"))
            {
                zodiac = "Capricornus";
            }


            Console.WriteLine(day + " " + month + " is " + zodiac);
        }
    }
}
