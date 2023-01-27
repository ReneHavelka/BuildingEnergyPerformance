using Domain.Common;

namespace Domain.Entities
{
	public record Storeys : IdName
	{
		public List<Spaces> Spaces { get; set; }
	}
}
