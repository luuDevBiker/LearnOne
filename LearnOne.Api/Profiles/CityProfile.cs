using AutoMapper;
using LearnOne.Api.ViewModels.Cties;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.Entities;

namespace LearnOne.Api.Profiles {
    public class CityProfile : Profile {
        public CityProfile()
        {
            CreateMap<CreateCityViewModel, CityDto>();
            CreateMap<UpdateCityViewModel, CityDto>();
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
