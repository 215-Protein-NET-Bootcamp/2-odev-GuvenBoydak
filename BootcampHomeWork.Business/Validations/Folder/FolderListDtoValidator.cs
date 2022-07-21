using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class FolderListDtoValidator : AbstractValidator<FolderListDto>
    {
        public FolderListDtoValidator()
        {
            RuleFor(x => x.AccessType).NotEmpty().WithMessage("Ülke ismi Boş geçilemez").MaximumLength(5).WithMessage("Erişim türü maksimum 5 karakter olamlıdır.");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("EmployeeId Boş geçilemez").GreaterThan(0).WithMessage("EmployeeId 0 dan büyük olamalıdır.");
        }
    }
}
