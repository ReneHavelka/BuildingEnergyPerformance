using Domain.Common;

namespace Domain.Entities
{
	public record Spaces : IdName
	{
		public float Temperature { get; set; }

		public List<BuildingElements> BuildingElements { get; set; }

		public int StoreysId { get; set; }
		public Storeys Storeys { get; set; }
	}
}
