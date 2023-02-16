using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using System.Diagnostics;

namespace Application.StoreyCQR.Commands
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

		public async Task AddStoreyAsync(StoreyDto storeyDto)
		{
			StoreyCommandValidator storeyCommandValidator = new(storeyDto, _context);
			await storeyCommandValidator.ValidateAndThrowAsync(storeyDto);

			Storey storey = _mapper.Map<Storey>(storeyDto);

			await _context.Storeys.AddAsync(storey);
			await _context.SaveChangesAsync();
		}
	}
}
