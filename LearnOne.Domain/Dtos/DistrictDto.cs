using LearnOne.Domain.Entities;
using LearnOne.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Domain.Dtos {
    public class DistrictDto : Entity<Guid> {
        public Guid CtyId { get; set; }
        public string Name { get; set; }
        public virtual City Cty { get; set; }
        public ICollection<Ward> Wards { get; set; }
    }
}
