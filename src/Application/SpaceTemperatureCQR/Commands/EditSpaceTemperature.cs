using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.SpaceTemperatureCQR.Commands
{
	public class EditSpaceTemperature
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditSpaceTemperature(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task ModifySpaceTemperature(SpaceTemperatureDto spaceTemperatureDto)
		{
			SpaceTemperature spaceTemperature = _mapper.Map<SpaceTemperature>(spaceTemperatureDto);
			_context.SpaceTemperatures.Update(spaceTemperature);
			await _context.SaveChangesAsync();
		}
	}
}
