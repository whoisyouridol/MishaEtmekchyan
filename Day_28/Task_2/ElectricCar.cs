using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    class ElectricCar
    {
        public int BatteryLevel { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public void ChargeOneCar()
        {
            while (BatteryLevel < 100)
            {
                var sw = new Stopwatch();
                sw.Start();
                //here should be 10 sec
                while (sw.Elapsed.TotalSeconds < 1) { }

                BatteryLevel += 5;
                Console.WriteLine($"Seconds (while charging 1 car) : {sw.Elapsed.TotalSeconds}, battery level : {BatteryLevel}, car brand {Model}");
            }
        }
        public async static Task ChargeManyCars(IEnumerable<ElectricCar> cars)
        {
            var sw = new Stopwatch();
            sw.Start();
            var tasks = new List<Task>();
            foreach (var car in cars)
            {
                tasks.Add(Task.Run(() => car.ChargeOneCar()));
            }
            await Task.WhenAll(tasks);
            Console.WriteLine($"Seconds(while charging multiple cars) : {sw.Elapsed.TotalSeconds}");

        }
    }
}