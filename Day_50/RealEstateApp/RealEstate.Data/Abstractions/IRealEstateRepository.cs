using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RealEstate;
namespace RealEstate.Data.Abstractions
{
    public interface IRealEstateRepository
    {
        Task<List<Domain.RealEstate>> GetAllAsync();

        Task<Domain.RealEstate> GetAsync(string id);

        Task CreateAsync(Domain.RealEstate building);

        Task UpdateAsync(Domain.RealEstate building);

        Task DeleteAsync(Domain.RealEstate building);
    }
}
