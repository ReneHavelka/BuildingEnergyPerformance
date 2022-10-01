using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BuildingElementsCQR.Commands
{
    public class DeleteBuildingElement
    {
        IApplicationDbContext _context;
        public DeleteBuildingElement(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RemoveBuildingElement(GetBuildingElementsWithSpaces BuildingElementDto)
        {
            var buildingElement = _context.BuildingElements.Find(BuildingElementDto.Id);
            _context.BuildingElements.Remove(buildingElement);
            await _context.SaveChangesAsync();
        }
    }
}
