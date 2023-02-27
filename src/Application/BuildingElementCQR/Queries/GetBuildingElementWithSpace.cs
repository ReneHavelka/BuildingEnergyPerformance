using Application.Common.Interfaces;

namespace Application.BuildingElementCQR.Queries
{
    public class GetBuildingElementWithSpace
    {
        IApplicationDbContext _context;
        int _id;

        public GetBuildingElementWithSpace(IApplicationDbContext context, int id)
        {
            _context = context;
            _id = id;
        }

        public GetBuildingElementsWithSpaces GetBuildingElementWithSpaceDto()
        {
            var getBuildingElementsWithSpaces = new GetBuildingElementsWithSpaces();
            var getBuildingElementWithSpacesList = getBuildingElementsWithSpaces.GetBuildingElementsWithSpacesList(_context);
            var getBuildingElementWithSpaceDto = getBuildingElementWithSpacesList.FirstOrDefault(x => x.Id == _id);

            return getBuildingElementWithSpaceDto;
        }
    }
}
