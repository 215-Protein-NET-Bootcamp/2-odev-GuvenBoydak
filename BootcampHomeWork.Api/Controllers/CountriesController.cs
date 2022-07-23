using AutoMapper;
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
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Country> countries = await _countryService.GetActivesAsync();

            List<CountryListDto> countryListDto = _mapper.Map<List<CountryListDto>>(countries.ToList());

            return CreateActionResult(CustomResponseDto<List<CountryListDto>>.Success(200, countryListDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Country country = await _countryService.GetByIdAsync(id);

            //Girilen İd ait kayıt olup olmadıgını kontrol ediyoruz.
            if(country==null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,$"{typeof(Country).Name}({id}) Not Found "));

            CountryDto countryDto = _mapper.Map<CountryDto>(country);

            return CreateActionResult(CustomResponseDto<CountryDto>.Success(200, countryDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CountryAddDto countryAddDto)
        {
            Country country = _mapper.Map<Country>(countryAddDto);

            await _countryService.InsertAsync(country);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CountryUpdateDto countryUpdateDto)
        {


            Country country = _mapper.Map<Country>(countryUpdateDto);

            await _countryService.UpdateAsync(country);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _countryService.RemoveAsync(id);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
