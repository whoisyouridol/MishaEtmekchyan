using System.Collections.Generic;
using System.Threading.Tasks;
using PersonManagement.Services.Models;

namespace PersonManagement.Services.Abstractions
{
    public interface IPersonService
    {
        Task<List<PersonServiceModel>> GetAllAsync();
        Task<(Status status, PersonServiceModel)> GetAsync(int id);
        Task<(Status status, int id)> CreateAsync(PersonServiceModel person);
        Task<Status> UpdateAsync(PersonServiceModel person);
        Task<Status> DeleteAsync(int id);
    };
}
