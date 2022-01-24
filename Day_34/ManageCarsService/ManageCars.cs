using ManageCarsService.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCarsService
{
    public class ManageCars : IManagable
    {
        private List<Car> _cars = new List<Car>
        {
            new Car 
            {
                Name = "BMW",
                Year = 2010,
                Type = "Sedan"
            },

             new Car
            {
                Name = "Mercedes-benz",
                Year = 2014,
                Type = "Sedan"
            },
              new Car
            {
                Name = "Volvo",
                Year = 2000,
                Type = "Coupe"
            },
               new Car
            {
                Name = "Cadillac",
                Year = 2009,
                Type = "SUV"
            },
                new Car
            {
                Name = "Porsche",
                Year = 2017,
                Type = "Sedan"
            },
        };
        public async Task AddCarAsync(Car car)
        {
            if (car.Year > 1955)
            {
                _cars.Add(car);
            }
            else throw new CouldNotAddCarException("Couldn`t add new car because it is too old!");

            await Task.CompletedTask;
        }

        public async Task DeleteCarByNameAsync(string name)
        {
            var carToDelete = _cars.SingleOrDefault(x => x.Name == name);

            if (carToDelete == null)
              Debug.WriteLine("Car does not exists!");

            else
             _cars.Remove(carToDelete);

            await Task.CompletedTask;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await Task.FromResult(_cars);
        }

        public async Task<Car> GetCarByNameAsync(string name)
        {
            var result = _cars.SingleOrDefault(x => x.Name == name);

            if (result == null)
                throw new CarNotFoundException("Car with this name not found!");

            return await Task.FromResult(result);
        }

        public async Task UpdateCarNameAsync(string oldName,string newName)
        {
            var result = _cars.SingleOrDefault(x => x.Name == oldName);
            result.Name = newName;
            await Task.CompletedTask;
        }
    }
}
