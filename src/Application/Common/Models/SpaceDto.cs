namespace Application.Common.Models
{
    public record SpaceDto : IdNameDto
    {
        public float Temperature { get; set; }
        public int StoreyId { get; set; }
    }
}
