using Domain.Common;

namespace Domain.Entities
{
	public class Storeys : IdName
	{
		public List<Spaces> Spaces { get; set; }
	}
}
