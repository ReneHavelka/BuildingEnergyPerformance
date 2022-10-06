using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using Application.SpacesCQR.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.HandlerServices
{
    public class SelectBuildingElementArea
    {
        GetBuildingElement getBuildingElement;

        public SelectBuildingElementArea(IApplicationDbContext context, IMapper mapper)
        {
            getBuildingElement = new GetBuildingElement(context, mapper);
        }

        public float GetBuildingElementArea(int id)
        {
            var buildingElement = getBuildingElement.GetBuildingElementDto(id);
            var area = buildingElement.EffectiveArea;
            return area;
        }

    }
}
