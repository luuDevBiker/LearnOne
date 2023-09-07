using AutoMapper;
using LearnOne.Api.ViewModels.Cties;
using LearnOne.Domain.Dtos;
using LearnOne.Infastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnOne.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller {
        private readonly ICityService _ctyService;
        private readonly IMapper _mapper;
        public CityController(ICityService ctyService, IMapper mapper)
        {
            _ctyService = ctyService ?? throw new ArgumentNullException(nameof(ctyService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: api/<CtyController>
        [HttpGet]
        [EnableQuery]
        public Task<IQueryable> GetAsync(ODataQueryOptions<CityDto> queryOptions)
        {
            var results = _ctyService.Get().Result;
            var filnalResults = queryOptions.ApplyTo(results.AsQueryable());
            return Task.FromResult( filnalResults);
        }

        // GET api/<CtyController>/5
        [HttpGet("{key}")]
        [EnableQuery]
        public Task<CityDto> GetAsync([FromODataUri] Guid key)
        {
            return  Task.FromResult(_ctyService.Get().Result.FirstOrDefault(x => x.Id == key));
        }

        // POST api/<CtyController>
        [HttpPost]
        [EnableQuery]
        public async Task PostAsync([FromBody] CreateCityViewModel viewModel)
        {
            var cty = _mapper.Map<CityDto>(viewModel);
            await _ctyService.AddSync(cty);
        }

        // PUT api/<CtyController>/5
        [HttpPut]
        [EnableQuery]
        public async Task PutAsync([FromBody] UpdateCityViewModel viewModel)
        {
            var cty = _mapper.Map<CityDto>(viewModel);
            await _ctyService.UpdateSync(cty);
        }

        // DELETE api/<CtyController>/5
        [HttpDelete("{id}")]
        [EnableQuery]
        public async Task DeleteAsync(Guid id)
        {
            var cty = _ctyService.Get().Result.FirstOrDefault(x => x.Id == id);
            if (cty != null)
            {
                await _ctyService.AddSync(cty);
            }
        }
    }
}
