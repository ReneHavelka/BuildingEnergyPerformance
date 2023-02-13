using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics;

namespace Application.StoreysCQR.Commands
{
	public class CreateStorey
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateStorey(IApplicationDbContext context, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task AddStoreyAsync(StoreysDto storeyDto)
		{
			StoreyCommandValidator storeyCommandValidator = new(storeyDto, _context);
			await storeyCommandValidator.ValidateAndThrowAsync(storeyDto);

			Storeys storey = _mapper.Map<Storeys>(storeyDto);
			await _context.Storeys.AddAsync(storey);
			await _context.SaveChangesAsync();
		}
	}
}
