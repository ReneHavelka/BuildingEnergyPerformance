using Domain.Common;

namespace Domain.Entities
{
	public record Storey : IdName
	{
		public List<Space> Spaces { get; set; }
	}
}
