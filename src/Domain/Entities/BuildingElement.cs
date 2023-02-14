using Domain.Common;

namespace Domain.Entities
{
	public record BuildingElement : IdName
	{
		public int? ContiguousSpaceId { get; set; }
		public float EffectiveArea { get; set; }

		public List<Layer> Layers { get; set; }

		public int SpaceId { get; set; }
		public Space Space { get; set; }
	}
}
