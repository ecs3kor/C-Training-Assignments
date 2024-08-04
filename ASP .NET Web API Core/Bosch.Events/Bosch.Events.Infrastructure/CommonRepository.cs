﻿using Bosch.Events.DAL;
using Bosch.Events.UseCases.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Bosch.Events.Infrastructure
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private readonly BoschEventsDbContext _dbContext;

        public CommonRepository(BoschEventsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetDetailsAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
