using AutoMapper;
using BootcampHomework.Entities;

namespace BootcampHomeWork.Business
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryListDto>().ReverseMap();
            CreateMap<Country, CountryAddDto>().ReverseMap();
            CreateMap<Country, CountryUpdateDto>().ReverseMap();
        }
    }
}
