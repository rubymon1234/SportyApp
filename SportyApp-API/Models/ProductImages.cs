using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportyApp.Models
{
    [Table("ProductImages")]
    public class ProductImages
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string path { get; set; }
        public int productId { get; set; }
        public Products products { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
