using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BuildingElements : IdName
    {
        public int ContiguousSpaceId { get; set; }
        public float Dimension1 { get; set; }
        public float Dimension2 { get; set; }

        public List<BuildingElementComponents> BuildingElementComponents { get; set; }

        public int SpacesId { get; set; }
        public Spaces Spaces { get; set; }
    }
}
