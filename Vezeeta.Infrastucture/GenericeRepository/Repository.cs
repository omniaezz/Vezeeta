using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Application.Contract.GenericContract;
using Vezeeta.Context;

namespace Vezeeta.Infrastucture.GenericeRepository
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
             => (await _entities.AddAsync(entity)).Entity;


        public Task<TEntity> DeleteAsync(TEntity entity)
             => Task.FromResult(_entities.Remove(entity).Entity);


        public Task<IQueryable<TEntity>> GetAllAsync()
             => Task.FromResult(_entities.Select(e => e));


        public async Task<TEntity> GetByIdAsync(TId id)
             => await _entities.FindAsync(id);


        public async Task<int> SaveChangesAsync()
            => await _vezeetaContext.SaveChangesAsync();


        public Task<TEntity> UpdateAsync(TEntity entity)
            => Task.FromResult(_entities.Update(entity).Entity);
    }
}
