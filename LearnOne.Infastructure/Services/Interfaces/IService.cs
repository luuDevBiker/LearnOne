using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Infastructure.Services.Interfaces {
    public interface IService<TEntity> where TEntity : class {
        Task<List<TEntity>> Get();
        Task AddSync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateSync(TEntity entity);
    }
}
