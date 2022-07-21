using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class DepartmentUpdateDtoValidator : AbstractValidator<DepartmentUpdateDto>
    {
        public DepartmentUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş geçilemez").GreaterThan(0).WithMessage("Id alanı 0 dan büyük olamlıdır.");
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Departman ismi Boş geçilemez").MaximumLength(10).WithMessage("Departman ismi maksimum 10 karakter olamlıdır.");
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId Boş geçilemez").GreaterThan(0).WithMessage("CountryId 0 dan büyük olamalıdır.");
        }
    }

}
