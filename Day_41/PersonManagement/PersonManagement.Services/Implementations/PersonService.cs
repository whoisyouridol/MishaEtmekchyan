using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using PersonManagement.Data;
using PersonManagement.Domain.POCO;
using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Models;

namespace PersonManagement.Services.Implementations
{
    public class PersonService : IPersonService
    {
        #region Private Members

        private IPersonRepository _repo;

        #endregion

        #region Ctor

        public PersonService(IPersonRepository repo)
        {
            _repo = repo;
        }

        #endregion

        public async Task<List<PersonServiceModel>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();

            return result.Adapt<List<PersonServiceModel>>();
        }
        public async Task<(Status, PersonServiceModel)> GetAsync(int id)
        {
            var result = await _repo.GetAsync(id);

            if (result == null)
                return (Status.NotFound, null);

            return (Status.Success, result.Adapt<PersonServiceModel>());
        }
        public async Task<(Status, int)> CreateAsync(PersonServiceModel person)
        {
            var personToInsert = person.Adapt<Person>();

            int insertedId = await _repo.CreateAsync(personToInsert);

            return (Status.Success, insertedId);
        }
        public async Task<Status> DeleteAsync(int id)
        {
            if (!await _repo.Exists(id))
                return Status.NotFound;

            await _repo.DeleteAsync(id);

            return Status.Success;
        }
        public async Task<Status> UpdateAsync(PersonServiceModel person)
        {
            if (!(await _repo.Exists(person.Id)))
                return Status.NotFound;

            var personToUpdate = person.Adapt<Person>();

            await _repo.UpdateAsync(personToUpdate);

            return Status.Success;
        }
    }
}
