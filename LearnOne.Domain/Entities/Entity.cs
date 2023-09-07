using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

public abstract class Entity : IEntity {
}
public abstract class Entity<TKey> : Entity, IEntity<TKey>, IEntity {
    [Key]
    [Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual TKey Id { get; protected set; }
}

