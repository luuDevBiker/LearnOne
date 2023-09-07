using AutoMapper;
using LearnOne.Api.ViewModels.Cties;
using LearnOne.Api.ViewModels.Districts;
using LearnOne.Domain.Dtos;
using LearnOne.Domain.Entities;
using LearnOne.Infastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;

namespace LearnOne.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : Controller {
        private readonly IDistrictService _districtService;
        private readonly IMapper _mapper;
        public DistrictsController(IDistrictService ctyService, IMapper mapper)
        {
            _districtService = ctyService ?? throw new ArgumentNullException(nameof(ctyService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<CtyController>
        [HttpGet]
        [EnableQuery]
        public Task<IQueryable> GetAsync(ODataQueryOptions<DistrictDto> queryOptions)
        {
            var results = _districtService.Get().Result;
            var filnalResults = queryOptions.ApplyTo(results.AsQueryable());
            return Task.FromResult(filnalResults);
        }

        // GET api/<CtyController>/5
        [HttpGet("{key}")]
        [EnableQuery]
        public Task<DistrictDto> GetAsync([FromODataUri] Guid key)
        {
            return Task.FromResult(_districtService.Get().Result.FirstOrDefault(x => x.Id == key));
        }

        // POST api/<CtyController>
        [HttpPost]
        [EnableQuery]
        public async Task PostAsync([FromBody] CreateDistrictViewModel viewModel)
        {
            var district = _mapper.Map<DistrictDto>(viewModel);
            await _districtService.AddSync(district);
        }

        // PUT api/<CtyController>/5
        [HttpPut]
        [EnableQuery]
        public async Task PutAsync([FromBody] UpdateDistrictViewModel viewModel)
        {
            var district = _mapper.Map<DistrictDto>(viewModel);
            await _districtService.UpdateSync(district);
        }

        // DELETE api/<CtyController>/5
        [HttpDelete("{id}")]
        [EnableQuery]
        public async Task DeleteAsync(Guid id)
        {
            var district = _districtService.Get().Result.FirstOrDefault(x => x.Id == id);
            if (district != null)
            {
                await _districtService.AddSync(district);
            }
        }
    }
}
