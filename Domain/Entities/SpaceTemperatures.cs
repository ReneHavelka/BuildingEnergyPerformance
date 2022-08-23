using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SpaceTemperatures : IdName
    {
        public float Temperature { get; set; }
    }
}
