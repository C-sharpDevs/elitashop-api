using System.ComponentModel.DataAnnotations;

namespace ElitaShop.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
