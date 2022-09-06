using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.BuildingElementsCQR.Commands
{
    public class CreateBuildingElement
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public CreateBuildingElement(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddBuildingElement(BuildingElementsDto buildingElementDto)
        {
            BuildingElements buildingElement = _mapper.Map<BuildingElements>(buildingElementDto);
            await _context.BuildingElements.AddAsync(buildingElement);
            await _context.SaveChangesAsync();
        }
    }
}
