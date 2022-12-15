using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SpaceTemperaturesCQR.Commands
{
	public class CreateSpaceTemperature

	{
		IApplicationDbContext _context;
		private IMapper _mapper;
		public CreateSpaceTemperature(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddSpaceTemperature(SpaceTemperaturesDto spaceTemperatureDto)
		{
			SpaceTemperatures spaceTemperature = _mapper.Map<SpaceTemperatures>(spaceTemperatureDto);
			await _context.SpaceTemperatures.AddAsync(spaceTemperature);
			await _context.SaveChangesAsync();
		}
	}
}
