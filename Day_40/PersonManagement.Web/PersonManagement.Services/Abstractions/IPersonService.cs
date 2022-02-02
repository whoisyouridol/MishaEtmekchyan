using PersonManagement.Services.Models;
using PersonManagement.Services.Models.@enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManagement.Services.Abstractions
{
    public interface IPersonService
    {
        Task<List<PersonServiceModel>> GetAllAsync();
        Task<(Status status, PersonServiceModel)> GetAsync(int id);
        Task<(Status status,int id)> CreatAsync(PersonServiceModel person);
        Task<Status> UpdateAsync(PersonServiceModel person);
        Task<Status> DeleteAsync(int id);
    }
}
