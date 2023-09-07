using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnOne.Data.IRepositories {
    public interface IDbContextCore<TEntity> where TEntity : class {
        DbSet<TEntity> Entities { get; set; }

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> RemoveAsync(TEntity entity);

        Task<IEnumerable<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities);

        IQueryable<TEntity> AsQueryable();

        Task<int> SaveChangesAsync();
    }
}
