using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.BuildingElementCQR.Queries
{
	public class GetBuildingElement
	{
		IApplicationDbContext _context;
		IMapper _mapper;
		public int StoreyId { get; set; }

		public GetBuildingElement(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public BuildingElementDto GetBuildingElementDto(int id)
		{
			var buildingElement = _context.BuildingElements.Find(id);
			var buildingElementDto = _mapper.Map<BuildingElementDto>(buildingElement);
			var space = _context.Spaces.Find(buildingElementDto.SpaceId);
			StoreyId = space.StoreyId;
			return buildingElementDto;
		}
	}
}
