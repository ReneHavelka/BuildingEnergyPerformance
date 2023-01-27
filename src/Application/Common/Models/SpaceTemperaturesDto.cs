namespace Application.Common.Models
{
	public record SpaceTemperaturesDto : IdNameDto
	{
		public float Temperature { get; set; }
	}
}
