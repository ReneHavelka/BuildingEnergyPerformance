using Domain.Common;

namespace Domain.Entities
{
    public class InsulatingLayers : IdName
    {
        public float? Thickness { get; set; }

        public int WallComponentsId { get; set; }
        public BuildingElementComponents WallComponents { get; set; }
    }
}
