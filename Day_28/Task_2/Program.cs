using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var obj = new ElectricCar();
            //obj.ChargeOneCar();

            var cars = new List<ElectricCar>()
            { 
                new ElectricCar {BatteryLevel = 15, Model = "Tesla", Year = 2015 },
                new ElectricCar {BatteryLevel = 21, Model = "BMW", Year = 2009 },
                new ElectricCar {BatteryLevel = 15, Model = "Mazda", Year = 1999 },
                new ElectricCar {BatteryLevel = 1, Model = "Volvo", Year = 2015 },
                new ElectricCar {BatteryLevel = 56, Model = "Alfa-Romeo", Year = 2015 },
                new ElectricCar {BatteryLevel = 29, Model = "Porsche", Year = 2009 },
                new ElectricCar {BatteryLevel = 33, Model = "Chevrolet", Year = 2018}
            };

            await ElectricCar.ChargeManyCars(cars);
        }
    }
}
