namespace Application.Common.Models
{
	public record SpaceTemperatureDto : IdNameDto
	{
		public float Temperature { get; set; }
	}
}
