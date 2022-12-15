using Application.BuildingElementsCQR.Queries;
using Application.Common.Interfaces;
using AutoMapper;

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
