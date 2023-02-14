using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using FluentValidation;

namespace Application.StoreyCQR.Commands
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

		public async Task ModifyStoreyAsync(StoreyDto storeyDto)
		{
			StoreyCommandValidator storeyCommandValidator = new(storeyDto, _context);
			await storeyCommandValidator.ValidateAndThrowAsync(storeyDto);


			Storey storey = _mapper.Map<Storey>(storeyDto);
			_context.Storeys.Update(storey);
			Task updateStorey = _context.SaveChangesAsync();
			await updateStorey;
		}
	}
}
