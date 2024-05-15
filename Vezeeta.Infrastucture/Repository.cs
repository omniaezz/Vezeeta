using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract;
using Vezeeta.Context;

namespace Vezeeta.Infrastucture
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly VezeetaContext _vezeetaContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(VezeetaContext vezeetaContext)
        {
            _vezeetaContext = vezeetaContext;
            _entities = _vezeetaContext.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return (await _entities.AddAsync(entity)).Entity;
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Task.FromResult(_entities.Remove(entity).Entity);
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_entities.Select(e => e));
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _vezeetaContext.SaveChangesAsync();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(_entities.Update(entity).Entity);
        }
    }
}
