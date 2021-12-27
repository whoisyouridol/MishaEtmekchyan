using System;

namespace Day_18_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cows = new LinkedItem<Cow>();

            cows.AddItem(new Cow(5545, "faqizo"));
            cows.AddItem(new Cow(2342, "Lamazo"));
            cows.AddItem(new Cow(1111, "Cow 3"));
            cows.AddItem(new Cow(3333, "Cow 4"));
            cows.AddItem(new Cow(5555, "Cow 5"));


            //get values
            Console.WriteLine("Get values by indexes : ");
            cows[1].PrintItems();
            cows[4].PrintItems();


            //set values
            Console.WriteLine("Set values through indexer : ");
            var linkedTemp = new LinkedItem<Cow>();
            linkedTemp.AddItem(new Cow(2222, "Cow 6"));
            cows[3] = linkedTemp;
            cows[5].PrintItems();
           
        }
    }
}
