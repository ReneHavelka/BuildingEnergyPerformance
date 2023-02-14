using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.LayerCQR.Queries
{
	public class GetLayer
	{
		IApplicationDbContext _context;
		IMapper _mapper;
		public int SpaceId { get; set; }
		public int StoreyId { get; set; }

		public GetLayer(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public LayerDto GetLayerDto(int id)
		{
			var layer = _context.Layers.Find(id);
			var layerDto = _mapper.Map<LayerDto>(layer);

			var buildingElement = _context.BuildingElements.Find(layerDto.BuildingElementId);
			SpaceId = buildingElement.SpaceId;

			var space = _context.Spaces.Find(SpaceId);
			StoreyId = space.StoreyId;

			return layerDto;
		}
	}
}
