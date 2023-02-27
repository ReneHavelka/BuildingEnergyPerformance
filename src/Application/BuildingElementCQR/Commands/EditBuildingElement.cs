using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.BuildingElementCQR.Commands
{
    public class EditBuildingElement
    {
        IApplicationDbContext _context;
        IMapper _mapper;

        public EditBuildingElement(IApplicationDbContext conext, IMapper mapper)
        {
            _context = conext;
            _mapper = mapper;
        }

        public async Task ModifyBuildingElement(BuildingElementDto buildingElementsDto)
        {
            var buildingElement = _mapper.Map<BuildingElement>(buildingElementsDto);
            _context.BuildingElements.Update(buildingElement);
            await _context.SaveChangesAsync();
        }
    }
}
