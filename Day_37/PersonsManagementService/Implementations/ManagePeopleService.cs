using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManagementService.Abstractions;
using UsersManagementService.Models;

namespace UsersManagementService.Implementations
{
    public class ManagePeopleService : IManagePeopleService
    {
        private List<PersonModel> _people = new List<PersonModel>();

        public async Task AddAsync(PersonModel person)
        {
            if (person != null)
            {
                if (_people.Any())
                    person.Id = _people.Max(x => x.Id) + 1;
                else person.Id = 1;

                _people.Add(person);

                await Task.CompletedTask;
            }
        }

        public async Task<IEnumerable<PersonModel>> GetPeopleAsync()
        {
            return await Task.FromResult(_people);
        }
    }
}