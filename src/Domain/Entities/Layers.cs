using Domain.Common;

namespace Domain.Entities
{
	public record Layers : IdName
	{

		public float? Thickness { get; set; }
		public float? ThermalConductivity { get; set; }
		public float? ThermalResistance { get; set; }

		public int BuildingElementsId { get; set; }
		public BuildingElements BuildingElements { get; set; }
	}
}
