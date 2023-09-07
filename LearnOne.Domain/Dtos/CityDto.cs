using LearnOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Domain.Dtos {
    public class CityDto : Entity<Guid> {
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual IList<District> Districts { get; set; }
    }
}
