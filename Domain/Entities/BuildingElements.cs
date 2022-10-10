using Domain.Common;

namespace Domain.Entities
{
	public class BuildingElements : IdName
	{
		public int? ContiguousSpaceId { get; set; }
		public float EffectiveArea { get; set; }

		public List<Layers> Layers { get; set; }

		public int SpacesId { get; set; }
		public Spaces Spaces { get; set; }
	}
}
