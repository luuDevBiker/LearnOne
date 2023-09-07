using LearnOne.Domain.Entities;

namespace LearnOne.Api.ViewModels.Cties {
    public class UpdateCityViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual IList<District> Districts { get; set; }
    }
}
