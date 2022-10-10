using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.LayersCQR.Commands
{
	public class CreateLayers
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateLayers(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddLayer(LayersDto layerDto)
		{
			Layers layer = _mapper.Map<Layers>(layerDto);
			await _context.Layers.AddAsync(layer);
			await _context.SaveChangesAsync();
		}
	}
}
