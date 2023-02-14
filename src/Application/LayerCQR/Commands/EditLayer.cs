using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.LayerCQR.Commands
{
	public class EditLayer
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditLayer(IApplicationDbContext conext, IMapper mapper)
		{
			_context = conext;
			_mapper = mapper;
		}

		public async Task ModifyLayer(LayerDto layerDto)
		{
			var layer = _mapper.Map<Layer>(layerDto);
			_context.Layers.Update(layer);
			await _context.SaveChangesAsync();

		}
	}
}
