namespace Application.Common.Models
{
	public record LayersDto : IdNameDto
	{
		public float? Thickness { get; set; }
		public float? ThermalConductivity { get; set; }
		public float? ThermalResistance { get; set; }
		public int BuildingElementsId { get; set; }
	}
}
