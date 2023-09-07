using LearnOne.Domain.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Domain.Entities {
    public class District : Entity<Guid> {
        public District(Guid id)
        {
            this.Id = id;
        }
        public Guid CtyId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public virtual City Cty { get; set; }
        public ICollection<Ward> Wards { get; set; }
    }
}
