using BootcampHomework.Entities;
using FluentValidation;

namespace BootcampHomeWork.Business
{
    public class CountryListDtoValidator : AbstractValidator<CountryListDto>
    {
        public CountryListDtoValidator()
        {
            RuleFor(x => x.CountryName).NotEmpty().WithMessage("Ülke ismi Boş geçilemez").MaximumLength(30).WithMessage("Ülke ismi maksimum 30 karakter olamlıdır.");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Para birimi Boş geçilemez").Matches("^[a-zA-Z]*$").Length(3).WithMessage("Para birimi sadece Harf ve ^karakterli olamalıdır.");
            RuleFor(x => x.Continent).NotEmpty().WithMessage("Kıta ismi kısaltması Boş geçilemez").MaximumLength(10).WithMessage("kıta ismi maksimum 10 karakter olamlıdır.");
        }
    }
}
