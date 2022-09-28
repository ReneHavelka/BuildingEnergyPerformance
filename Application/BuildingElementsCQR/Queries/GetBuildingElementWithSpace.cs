using Application.Common.Interfaces;
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


    }
}
