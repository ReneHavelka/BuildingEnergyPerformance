using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class IdName
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
