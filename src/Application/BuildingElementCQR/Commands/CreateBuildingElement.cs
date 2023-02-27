using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.BuildingElementCQR.Commands
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

        public async Task AddBuildingElement(BuildingElementDto buildingElementDto)
        {
            BuildingElement buildingElement = _mapper.Map<BuildingElement>(buildingElementDto);
            await _context.BuildingElements.AddAsync(buildingElement);
            await _context.SaveChangesAsync();
        }
    }
}
