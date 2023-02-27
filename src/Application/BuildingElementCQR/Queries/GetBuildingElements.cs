using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;

namespace Application.BuildingElementCQR.Queries
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

        public IList<BuildingElementDto> GetBuildingElementDtoList()
        {
            var buildingElements = _context.BuildingElements;
            var buildingElementsDto = _mapper.Map<IList<BuildingElementDto>>(buildingElements);
            return buildingElementsDto;
        }

    }
}
