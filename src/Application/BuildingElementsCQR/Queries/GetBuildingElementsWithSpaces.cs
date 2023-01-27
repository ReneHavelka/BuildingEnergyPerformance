using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.BuildingElementsCQR.Queries
{
	public record GetBuildingElementsWithSpaces : IdNameDto
	{
		public string StoreyName { get; set; }
		public string SpaceName { get; set; }
		public float Temperature { get; set; }
		public float EffectiveArea { get; set; }
		public string? ContiguousSpaceName { get; set; }

		public IList<GetBuildingElementsWithSpaces> GetBuildingElementsWithSpacesList(IApplicationDbContext context)
		{
			var buildingElements = context.BuildingElements;
			var spaces = context.Spaces;
			var storeys = context.Storeys;

			var buildingElementsQueryable = from be in buildingElements
											join sp in spaces on be.SpacesId equals sp.Id
											join st in storeys on sp.StoreysId equals st.Id
											join csp in spaces on be.ContiguousSpaceId equals csp.Id into cspj
											from cspItem in cspj.DefaultIfEmpty()
											select new GetBuildingElementsWithSpaces
											{
												Id = be.Id,
												Name = be.Name,
												StoreyName = st.Name,
												SpaceName = sp.Name,
												Temperature = sp.Temperature,
												EffectiveArea = be.EffectiveArea,
												ContiguousSpaceName = cspItem == null ? "Vonkajší priestor" : cspItem.Name
											};

			IList<GetBuildingElementsWithSpaces> getBuildingElementsWithSpaces = buildingElementsQueryable.ToList();

			return getBuildingElementsWithSpaces;
		}
	}
}
