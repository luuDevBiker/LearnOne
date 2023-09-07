 using LearnOne.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnOne.Data.Repositories {
    public class DbContextCore<TEntity> : IDbContextCore<TEntity> where TEntity : class, IEntity {
        private readonly DbContext _dbContext;
        public DbSet<TEntity> Entities { get; set; }
        public DbContextCore(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("DbContext");
            Entities = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await Entities.AddAsync(entity)).Entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            IEnumerable<TEntity> addedEntities = entities.Select(delegate (TEntity entity)
            {
                return entity;
            });
            await Entities.AddRangeAsync(addedEntities);
            return addedEntities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.FromResult(Entities.Update(entity).Entity);
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            IEnumerable<TEntity> enumerable = entities.Select(delegate (TEntity entity)
            {
                return entity;
            });
            Entities.UpdateRange(enumerable);
            return await Task.FromResult(enumerable);
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {
            return await Task.FromResult(Entities.Remove(entity).Entity);
        }

        public async Task<IEnumerable<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
            return await Task.FromResult(entities);
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return (IQueryable<TEntity>)_dbContext.Set<TEntity>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}