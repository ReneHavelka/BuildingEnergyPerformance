using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.BuildingElementsCQR.Queries
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

		public BuildingElementsDto GetBuildingElementDto(int id)
		{
			var buildingElement = _context.BuildingElements.Find(id);
			var buildingElementDto = _mapper.Map<BuildingElementsDto>(buildingElement);
			var space = _context.Spaces.Find(buildingElementDto.SpacesId);
			StoreyId = space.StoreysId;
			return buildingElementDto;
		}
	}
}
