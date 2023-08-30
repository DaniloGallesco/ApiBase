using ClubeAss.Domain.Enum.Base;
using ClubeAss.Domain.Interface.Application.Base;
using ClubeAss.Domain.Interface.Repository.IBase;
using ClubeAss.Repository.Ef.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubeAss.Repository.Ef.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BaseContext _dbContext;
        public GenericRepository(BaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);

        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {

            return await _dbContext.Set<T>().ToListAsync();

        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
       
    }
}
