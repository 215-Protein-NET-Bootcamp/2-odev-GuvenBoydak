using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class DepartmentListDtoValidator : AbstractValidator<DepartmentListDto>
    {
        public DepartmentListDtoValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Departman ismi Boş geçilemez").MaximumLength(10).WithMessage("Departman ismi maksimum 10 karakter olamlıdır.");
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId Boş geçilemez").GreaterThan(0).WithMessage("CountryId 0 dan büyük olamalıdır.");
        }
    }

}
