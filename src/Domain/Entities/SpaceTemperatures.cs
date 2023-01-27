using Domain.Common;

namespace Domain.Entities
{
	public record SpaceTemperatures : IdName
	{
		public float Temperature { get; set; }
	}
}
