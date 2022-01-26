using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersManagementService.Models;

namespace UsersManagementService.Abstractions
{
    public interface IManagePeopleService
    {
        Task AddAsync(PersonModel person);
        Task<IEnumerable<PersonModel>> GetPeopleAsync(); 
    }
}
