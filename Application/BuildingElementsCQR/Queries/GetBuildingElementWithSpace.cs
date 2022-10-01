using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BuildingElementsCQR.Queries
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
            var getBuildingElementWithSpaceDto = getBuildingElementWithSpacesList.First(x => x.Id == _id);

            return getBuildingElementWithSpaceDto;
        }
    }
}
