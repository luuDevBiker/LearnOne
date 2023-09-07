using LearnOne.Data.Repositories.Interfaces;
using LearnOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Data.Repositories.Implements
{
    public class DistrictRepository : DbContextCore<District>, IDistrictRepository
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
