using LearnOne.Domain.ObjectValues;

namespace LearnOne.Api.ViewModels.Districts {
    public class UpdateDistrictViewModel {
        public Guid CtyId { get; set; }
        public string Name { get; set; }
        public ICollection<Ward> Wards { get; set; }
    }
}
