using Domain.Common;

namespace Domain.Entities
{
	public record Space : IdName
	{
		public float Temperature { get; set; }

		public List<BuildingElement> BuildingElements { get; set; }

		public int StoreyId { get; set; }
		public Storey Storey { get; set; }
	}
}
