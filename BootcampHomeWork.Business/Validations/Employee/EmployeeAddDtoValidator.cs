using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class EmployeeAddDtoValidator:AbstractValidator<EmployeeAddDto>
    {
        public EmployeeAddDtoValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Çalişan ismi Boş geçilemez").MaximumLength(20).WithMessage("Çalişan ismi maksimum 20 karakter olamlıdır.");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("DepartmentId Boş geçilemez").GreaterThan(0).WithMessage("DepartmentId 0 dan büyük olamalıdır.");
        }
    }
}
