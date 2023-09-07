using LearnOne.Data.IRepositories;
using LearnOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Data.Repositories.Interfaces
{
    public interface ICtyRepository : IDbContextCore<City>
    {
    }
}
