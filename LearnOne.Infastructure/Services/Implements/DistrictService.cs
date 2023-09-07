using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnOne.Data.Repositories.Interfaces;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.Entities;
using LearnOne.Infastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnOne.Infastructure.Services.Implements {
    public class DistrictService : IDistrictService {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;
        public DistrictService(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository ?? throw new ArgumentNullException(nameof(districtRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task AddSync(DistrictDto entity)
        {
            var district = new District(new Guid());
            _mapper.Map(entity, district);
            await _districtRepository.AddAsync(district);
            await _districtRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(DistrictDto entity)
        {
            var district = _mapper.Map<District>(entity);
            await _districtRepository.RemoveAsync(district);
            await _districtRepository.SaveChangesAsync();
        }

        public Task<List<DistrictDto>> Get()
        {
            return Task.FromResult(_districtRepository.AsQueryable().AsNoTracking().ProjectTo<DistrictDto>(_mapper.ConfigurationProvider).ToList());
        }

        public async Task UpdateSync(DistrictDto entity)
        {
            var district = _mapper.Map<District>(entity);
            await _districtRepository.UpdateAsync(district);
            await _districtRepository.SaveChangesAsync();
        }
    }
}
