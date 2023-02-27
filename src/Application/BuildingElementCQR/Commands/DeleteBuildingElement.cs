using Application.BuildingElementCQR.Queries;
using Application.Common.Interfaces;

namespace Application.BuildingElementCQR.Commands
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
