using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.LayersCQR.Queries
{
	public record GetLayersWithBuildingElements : IdNameDto
	{
		public string StoreyName { get; set; }
		public string SpaceName { get; set; }
		public float Temperature { get; set; }
		public string BuildingElementName { get; set; }
		public float EffectiveArea { get; set; }
		public string? ContiguousSpaceName { get; set; }
		public float? Thickness { get; set; }
		public float? ThermalConductivity { get; set; }
		public float? ThermalResistance { get; set; }

		public IList<GetLayersWithBuildingElements> GetLayersWithBuildingElementsList(IApplicationDbContext context)
		{
			var layers = context.Layers;
			var buildingElements = context.BuildingElements;
			var spaces = context.Spaces;
			var storeys = context.Storeys;

			var layersWithBuildingElements = from lr in layers
											 join be in buildingElements on lr.BuildingElementsId equals be.Id
											 join sp in spaces on be.SpacesId equals sp.Id
											 join st in storeys on sp.StoreysId equals st.Id
											 join csp in spaces on be.ContiguousSpaceId equals csp.Id into cspj
											 from cspItem in cspj.DefaultIfEmpty()
											 select new GetLayersWithBuildingElements
											 {
												 Id = lr.Id,
												 Name = lr.Name,
												 StoreyName = st.Name,
												 SpaceName = sp.Name,
												 Temperature = sp.Temperature,
												 BuildingElementName = be.Name,
												 EffectiveArea = be.EffectiveArea,
												 ContiguousSpaceName = cspItem == null ? string.Empty : cspItem.Name,
												 Thickness = lr.Thickness,
												 ThermalConductivity = lr.ThermalConductivity,
												 ThermalResistance = lr.ThermalResistance
											 };

			IList<GetLayersWithBuildingElements> layersWithBuildingElementsList = layersWithBuildingElements.ToList();

			return layersWithBuildingElementsList;
		}
	}
}
