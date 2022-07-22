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

            CreateMap<Folder,FolderDto>().ReverseMap();
            CreateMap<Folder,FolderListDto>().ReverseMap();
            CreateMap<Folder,FolderAddDto>().ReverseMap();
            CreateMap<Folder,FolderUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeAddDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentListDto>().ReverseMap();
            CreateMap<Department, DepartmentAddDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();


        }
    }
}
