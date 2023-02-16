using Application.Common.Interfaces;
using Application.Common.Models;
using FluentValidation;
using System.Diagnostics;

namespace Application.StoreyCQR.Commands
{
	public class StoreyCommandValidator : AbstractValidator<StoreyDto>
	{
		public StoreyCommandValidator(StoreyDto storeyDto, IApplicationDbContext context)
		{
			RuleFor(storeyDto => storeyDto.Name)
				.NotEmpty().WithMessage("Meno je povinné.");
			RuleFor(storeyDto => storeyDto.Name)
				.MinimumLength(4).WithMessage("Meno musí pozostávať minimálne zo 4 znakov.");
			RuleFor(storeyDto => storeyDto.Name)
				.Matches(@"^[A-Z]").WithMessage("Meno musí začínať veľkým písmenom.");
			RuleFor(storeyDto => storeyDto.Name)
				.MaximumLength(20).WithMessage("Meno musí mať maximálne 20 znakov.");
		}
	}
}
