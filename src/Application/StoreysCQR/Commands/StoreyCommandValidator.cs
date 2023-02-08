using Application.Common.Interfaces;
using Application.Common.Models;
using FluentValidation;
using FluentValidation.Validators;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Application.StoreysCQR.Commands
{
	public class StoreyCommandValidator : AbstractValidator<StoreysDto>
	{
		public StoreyCommandValidator(StoreysDto storeyDto, IApplicationDbContext context)
		{
			var sameName = context.Storeys.Where(x => x.Name.Equals(storeyDto.Name) && !x.Id.Equals(storeyDto.Id)).Select(x => x.Name).FirstOrDefault();

			RuleFor(storeyDto => storeyDto.Name)
				.NotEmpty().WithMessage("Meno je povinné.");
			RuleFor(storeyDto => storeyDto.Name)
				.MinimumLength(4).WithMessage("Meno musí pozostávať minimálne zo 4 znakov.");
			RuleFor(storeyDto => storeyDto.Name)
				.Matches(@"^[A-Z]").WithMessage("Meno musí začínať veľkým písmenom.");
			RuleFor(storeyDto => storeyDto.Name)
				.MaximumLength(20).WithMessage("Meno musí mať maximálne 20 znakov.");
			RuleFor(storeyDto => storeyDto.Name)
				.NotEqual(sameName).When(storeyDto => storeyDto.Name != null).WithMessage("Toto meno je už použité. Zadajte iné.");
		}

	}
}
