namespace Application.Common.Models
{
	public record SpacesDto : IdNameDto
	{
		public float Temperature { get; set; }
		public int StoreysId { get; set; }
	}
}
