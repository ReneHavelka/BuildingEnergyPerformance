namespace Application.Common.Models
{
	public record BuildingElementDto : IdNameDto
	{
		public int? ContiguousSpaceId { get; set; }
		public float EffectiveArea { get; set; }
		public int SpaceId { get; set; }
	}
}
