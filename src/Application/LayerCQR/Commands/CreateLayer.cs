using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.LayerCQR.Commands
{
	public class CreateLayer
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public CreateLayer(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddLayer(LayerDto layerDto)
		{
			Layer layer = _mapper.Map<Layer>(layerDto);
			await _context.Layers.AddAsync(layer);
			await _context.SaveChangesAsync();
		}
	}
}
