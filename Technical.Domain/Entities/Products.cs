
using Technical.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Technical.Domain.Entities
{
    public class Products : Info
    {
        [Key]
        public int ProductID { get; set; }

    }
}
