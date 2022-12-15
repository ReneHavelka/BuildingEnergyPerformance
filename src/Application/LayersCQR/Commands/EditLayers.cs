using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.LayersCQR.Commands
{
	public class EditLayers
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public EditLayers(IApplicationDbContext conext, IMapper mapper)
		{
			_context = conext;
			_mapper = mapper;
		}

		public async Task ModifyLayer(LayersDto layerDto)
		{
			var layer = _mapper.Map<Layers>(layerDto);
			_context.Layers.Update(layer);
			await _context.SaveChangesAsync();

		}
	}
}
