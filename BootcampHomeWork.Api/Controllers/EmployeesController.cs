using AutoMapper;
using BootcampHomework.Entities;
using BootcampHomeWork.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampHomeWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Employee> employees = await _employeeService.GetAllAsync();

            List<EmployeeListDto> employeeListDto = _mapper.Map<List<EmployeeListDto>>(employees.ToList());

            return CreateActionResult(CustomResponseDto<List<EmployeeListDto>>.Success(200,employeeListDto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            Employee employee =await _employeeService.GetByIdAsync(id);

            //Girilen İd ait kayıt olup olmadıgını kontrol ediyoruz.
            if (employee == null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(Employee).Name}({id}) Not Found "));

            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(200,employeeDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]EmployeeAddDto employeeAddDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeAddDto);

            await _employeeService.InsertAsync(employee);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]EmployeeUpdateDto employeeUpdateDto)
        {
            Employee employee=_mapper.Map<Employee>(employeeUpdateDto);

            await _employeeService.UpdateAsync(employee);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _employeeService.RemoveAsync(id);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeDetails([FromRoute]int id)
        {
             List<EmployeeDetailsDto>  employeeDetails=await _employeeService.GetEmployeeDetails(id);

            return CreateActionResult(CustomResponseDto<List<EmployeeDetailsDto>>.Success(200, employeeDetails));
        }
    }
}
