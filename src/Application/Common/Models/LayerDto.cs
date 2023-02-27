namespace Application.Common.Models
{
    public record LayerDto : IdNameDto
    {
        public float? Thickness { get; set; }
        public float? ThermalConductivity { get; set; }
        public float? ThermalResistance { get; set; }
        public int BuildingElementId { get; set; }
    }
}
