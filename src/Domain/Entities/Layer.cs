using Domain.Common;

namespace Domain.Entities
{
	public record Layer : IdName
	{

		public float? Thickness { get; set; }
		public float? ThermalConductivity { get; set; }
		public float? ThermalResistance { get; set; }

		public int BuildingElementId { get; set; }
		public BuildingElement BuildingElement { get; set; }
	}
}
