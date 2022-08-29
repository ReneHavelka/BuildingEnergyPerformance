using Application.Common.Interfaces;
using Application.Common.Models;
using System.Collections.Generic;

namespace Application.BuildingElementsCQR.Queries
{
    public class GetBuildingElementsWithSpaces : IdNameDto
    {
        public int? ContiguousSpaceId { get; set; }
        public float EffectiveArea { get; set; }
        public float? ThermalResistance { get; set; }
        public int EmbededIn { get; set; }
        public string SpacesName { get; set; }
        public string StoreysName { get; set; }

        public IList<GetBuildingElementsWithSpaces> GetBuildingElementsWithSpacesList(IApplicationDbContext context)
        {
            var buildingElements = context.BuildingElements;
            var spaces = context.Spaces;
            var storeys = context.Storeys;

            var buildingElementsQueryable = from be in buildingElements
                                            join sp in spaces on be.SpacesId equals sp.Id
                                            join st in storeys on sp.StoreysId equals st.Id
                                            select new GetBuildingElementsWithSpaces
                                            {
                                                Id = be.Id,
                                                Name = be.Name,
                                                ContiguousSpaceId = be.ContiguousSpaceId,
                                                EffectiveArea = be.EffectiveArea,
                                                EmbededIn = be.EmbededIn,
                                                SpacesName = sp.Name,
                                                StoreysName = st.Name
                                            };

            IList<GetBuildingElementsWithSpaces> getBuildingElementsWithSpaces = buildingElementsQueryable.ToList();
            
            return getBuildingElementsWithSpaces;
        }
    }
}
