using AutoMapper;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Infastructure.Profiles {
    public class DistrictProfile : Profile {
        public DistrictProfile() {
            CreateMap<DistrictDto, District>();
        }
    }
}
