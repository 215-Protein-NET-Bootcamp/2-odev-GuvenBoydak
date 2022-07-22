using AutoMapper;
using BootcampHomework.Entities;
using BootcampHomeWork.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampHomeWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Department> departments =await _departmentService.GetActivesAsync();

            List<DepartmentListDto> departmentListDtos = _mapper.Map<List<DepartmentListDto>>(departments.ToList());

            return CreateActionResult(CustomResponseDto<List<DepartmentListDto>>.Success(200, departmentListDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            Department department =await _departmentService.GetByIdAsync(id);

            //Girilen İd ait kayıt olup olmadıgını kontrol ediyoruz.
            if (department == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(Department).Name}({id}) Not Found "));

            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);

            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmentDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DepartmentAddDto departmentAddDto)
        {
            Department department = _mapper.Map<Department>(departmentAddDto);

            await _departmentService.InsertAsync(department);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]DepartmentUpdateDto departmentUpdateDto)
        {
            Department department=_mapper.Map<Department>(departmentUpdateDto);

            await _departmentService.UpdateAsync(department);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _departmentService.RemoveAsync(id);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
