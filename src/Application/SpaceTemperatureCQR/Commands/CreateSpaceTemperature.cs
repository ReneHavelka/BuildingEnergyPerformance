using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SpaceTemperatureCQR.Commands
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

		public async Task AddSpaceTemperature(SpaceTemperatureDto spaceTemperatureDto)
		{
			SpaceTemperature spaceTemperature = _mapper.Map<SpaceTemperature>(spaceTemperatureDto);
			await _context.SpaceTemperatures.AddAsync(spaceTemperature);
			await _context.SaveChangesAsync();
		}
	}
}
