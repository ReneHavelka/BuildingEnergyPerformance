using Domain.Common;

namespace Domain.Entities
{
    public record SpaceTemperature : IdName
    {
        public float Temperature { get; set; }
    }
}
