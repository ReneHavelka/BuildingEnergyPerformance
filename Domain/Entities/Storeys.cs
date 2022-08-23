using Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Storeys : IdName
    {
        public List<Spaces> Spaces { get; set; }
    }
}
