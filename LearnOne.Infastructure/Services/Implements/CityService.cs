using AutoMapper;
using AutoMapper.QueryableExtensions;
using LearnOne.Data.Repositories.Implements;
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
    public class CityService : ICityService {
        private readonly ICtyRepository _ctyRepository;
        private readonly IMapper _mapper;

        public CityService(ICtyRepository ctyRepository, IMapper mapper)
        {
            _ctyRepository = ctyRepository ?? throw new ArgumentNullException(nameof(ctyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddSync(CityDto entity)
        {
            var cty = new City(new Guid());
            _mapper.Map(entity, cty);
            await _ctyRepository.AddAsync(cty);
            await _ctyRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(CityDto entity)
        {
            var cty = _mapper.Map<City>(entity);
            await _ctyRepository.RemoveAsync(cty);
            await _ctyRepository.SaveChangesAsync();
        }

        public Task<List<CityDto>> Get()
        {
            return Task.FromResult(_ctyRepository.AsQueryable().AsNoTracking().ProjectTo<CityDto>(_mapper.ConfigurationProvider).ToList());
        }

        public async Task UpdateSync(CityDto entity)
        {
            var cty = _mapper.Map<City>(entity);
            await _ctyRepository.UpdateAsync(cty);
            await _ctyRepository.SaveChangesAsync();
        }
    }
}
