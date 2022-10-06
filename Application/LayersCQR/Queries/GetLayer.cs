using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LayersCQR.Queries
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

		public LayersDto GetLayerDto(int id)
		{
			var layer = _context.Layers.Find(id);
			var layerDto = _mapper.Map<LayersDto>(layer);

			var buildingElement = _context.BuildingElements.Find(layerDto.BuildingElementsId);
			SpaceId = buildingElement.SpacesId;

			var space = _context.Spaces.Find(SpaceId);
			StoreyId = space.StoreysId;

			return layerDto;
		}
	}
}
