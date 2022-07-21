using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class FolderUpdateDtoValidator : AbstractValidator<FolderUpdateDto>
    {
        public FolderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Boş geçilemez").GreaterThan(0).WithMessage("Id 0 dan büyük olamlıdır.");
            RuleFor(x => x.AccessType).NotEmpty().WithMessage("Ülke ismi Boş geçilemez").MaximumLength(5).WithMessage("Erişim türü maksimum 5 karakter olamlıdır.");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("EmployeeId Boş geçilemez").GreaterThan(0).WithMessage("EmployeeId 0 dan büyük olamalıdır.");
        }
    }
}
