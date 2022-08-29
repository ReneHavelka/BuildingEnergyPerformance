using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class BuildingElementsDto : IdNameDto
    {
        public int? ContiguousSpaceId { get; set; }
        public float EffectiveArea { get; set; }
        public float? ThermalResistance { get; set; }
        public int EmbededIn { get; set; }
        public int SpacesId { get; set; }
    }
}
