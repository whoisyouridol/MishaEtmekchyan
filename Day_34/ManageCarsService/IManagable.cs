using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageCarsService
{
    public interface IManagable
    {
        Task AddCarAsync(Car car);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> GetCarByNameAsync(string name);
        Task UpdateCarNameAsync(string oldName, string newName);
        Task DeleteCarByNameAsync(string name);
    }
}