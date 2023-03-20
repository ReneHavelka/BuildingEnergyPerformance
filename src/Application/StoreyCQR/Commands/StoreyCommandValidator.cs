using Application.Common.Interfaces;
using Application.Common.Models;
using FluentValidation;

namespace Application.StoreyCQR.Commands
{
    public class StoreyCommandValidator : AbstractValidator<StoreyDto>
    {
        public StoreyCommandValidator(StoreyDto storeyDto, IApplicationDbContext context)
        {
            var sameStorey = context.Storeys.Where(x => x.Name.Equals(storeyDto.Name) && x.Id != storeyDto.Id).FirstOrDefault();
            string sameName = String.Empty;
            if (sameStorey != null) sameName = sameStorey.Name;

            RuleFor(storeyDto => storeyDto.Name)
                .NotEmpty().WithMessage("Meno je povinné.")
                .MinimumLength(4).WithMessage("Meno musí pozostávať minimálne zo 4 znakov.")
                .Matches(@"^[A-Z]").WithMessage("Meno musí začínať veľkým písmenom.")
                .MaximumLength(20).WithMessage("Meno musí mať maximálne 20 znakov.");
            RuleFor(storeyDto => storeyDto.Name)
                .NotEqual(sameName).When(storeyDto => storeyDto.Name != null).WithMessage("Toto meno je už použité. Zadaj iné.");
        }
    }
}
