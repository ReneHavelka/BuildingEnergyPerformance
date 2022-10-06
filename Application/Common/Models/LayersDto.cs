using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class LayersDto : IdNameDto
    {
        public float? Thickness { get; set; }
        public float? ThermalConductivity { get; set; }
        public float? ThermalResistance { get; set; }
        public int BuildingElementsId { get; set; }
    }
}
