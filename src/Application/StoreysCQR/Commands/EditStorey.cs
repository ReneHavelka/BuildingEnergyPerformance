using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics;

namespace Application.StoreysCQR.Commands
{
	public class EditStorey
	{
		IApplicationDbContext _context;
		IMapper _mapper;
		public EditStorey(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task ModifyStoreyAsync(StoreysDto storeyDto)
		{
			//var storeyNameValidation = new StoreyNameValidator();
			//storeyNameValidation.StoreyNameValidate(storeyDto, _context);
			StoreyCommandValidator storeyCommandValidator = new(storeyDto, _context);
			storeyCommandValidator.ValidateAndThrow(storeyDto);


			Storeys storey = _mapper.Map<Storeys>(storeyDto);
			_context.Storeys.Update(storey);
			Task updateStorey = _context.SaveChangesAsync();
			await updateStorey;
		}
	}
}
