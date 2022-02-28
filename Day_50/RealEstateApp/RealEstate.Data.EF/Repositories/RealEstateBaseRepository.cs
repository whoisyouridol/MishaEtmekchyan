using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Abstractions;
using RealEstate.PersistanceDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.EF.Repositories
{
    public class RealEstateBaseRepository<T> : IRealEstateBaseRepository<T> where T : class
    {
        protected readonly RealEstateContext _context;
        protected readonly DbSet<T> _dbSet;

        public RealEstateBaseRepository(RealEstateContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Table
        {
            get { return _dbSet; }
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(params object[] key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
