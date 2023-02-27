using Domain.Common;

namespace Domain.Entities
{
    public record Storey : IdName
    {
        public virtual List<Space> Spaces { get; set; }
    }
}
