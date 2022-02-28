using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.Abstractions
{
    public interface IRealEstateBaseRepository<T> where T : class
    {
        IQueryable<T> Table { get; }

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(params object[] key);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
