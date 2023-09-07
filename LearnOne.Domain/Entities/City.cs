namespace LearnOne.Domain.Entities
{
    public class City : Entity<Guid> {
        public City(Guid id)
        {
            this.Id = id;
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public virtual IList<District> Districts { get; set; }
    }
}