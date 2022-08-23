using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BuildingElementComponents : IdName
    {
        public float? Dimension1 { get; set; }
        public float? Dimension2 { get; set; }
        public float? Resistance { get; set; }


        public List<Layers>? Layers { get; set; }

        public int BuildingElementId { get; set; }
        public BuildingElements BuildingElements { get; set; }
    }
}
