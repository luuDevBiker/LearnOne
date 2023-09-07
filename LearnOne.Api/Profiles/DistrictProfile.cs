using AutoMapper;
using LearnOne.Api.ViewModels.Districts;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.Entities;

namespace LearnOne.Api.Profiles {
    public class DistrictProfile : Profile{
        public DistrictProfile()
        {
            CreateMap<CreateDistrictViewModel, DistrictDto>();
            CreateMap<UpdateDistrictViewModel, DistrictDto>();
            CreateMap<District, DistrictDto>().ReverseMap();
        }
    }
}
