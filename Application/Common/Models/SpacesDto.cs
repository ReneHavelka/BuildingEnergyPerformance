using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Common.Models
{
    public class SpacesDto : IdNameDto
    {
        public float Temperature { get; set; }
        public int StoreysId { get; set; }
    }
}
