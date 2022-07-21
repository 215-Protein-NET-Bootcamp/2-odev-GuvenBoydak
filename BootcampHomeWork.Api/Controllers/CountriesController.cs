using BootcampHomework.Entities;
using BootcampHomeWork.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampHomeWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var a = await _countryService.GetActivesAsync();
            return CreateActionResult(CustomResponseDto<IEnumerable<Country>>.Success(200, a));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Country country)
        {
            await _countryService.InsertAsync(country);

            return CreateActionResult(CustomResponseDto<Country>.Success(200,country));
        }
    }
}
