using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.BuildingElementsCQR.Queries
{
	public class GetBuildingElements
	{
		IApplicationDbContext _context;
		IMapper _mapper;

		public GetBuildingElements(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IList<BuildingElementsDto> GetBuildingElementDtoList()
		{
			var buildingElements = _context.BuildingElements;
			var buildingElementsDto = _mapper.Map<IList<BuildingElementsDto>>(buildingElements);
			return buildingElementsDto;
		}

	}
}
