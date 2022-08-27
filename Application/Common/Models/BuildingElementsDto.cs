using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    internal class BuildingElementsDto : IdNameDto
    {
        public int? ContiguousSpaceId { get; set; }
        public float Dimension1 { get; set; }
        public float Dimension2 { get; set; }
        public int SpacesId { get; set; }
    }
}
