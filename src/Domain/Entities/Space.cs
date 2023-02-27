using Domain.Common;

namespace Domain.Entities
{
    public record Space : IdName
    {
        public float Temperature { get; set; }

        public virtual List<BuildingElement> BuildingElements { get; set; }

        public int StoreyId { get; set; }
        public virtual Storey Storey { get; set; }
    }
}
