namespace Application.Common.Models
{
	public class BuildingElementsDto : IdNameDto
	{
		public int? ContiguousSpaceId { get; set; }
		public float EffectiveArea { get; set; }
		public int SpacesId { get; set; }
	}
}
