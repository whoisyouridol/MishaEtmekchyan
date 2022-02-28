using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Table { get; }

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(params object[] key);

        Task CreateAsync(List<T> entities);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAsync(List<T> entities);

    }
}
