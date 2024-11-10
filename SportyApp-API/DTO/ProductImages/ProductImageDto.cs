using System.ComponentModel.DataAnnotations;

namespace SportyApp.DTO.ProductImages
{
    public class ProductImageDto
    {
        [Required]
        public string path { get; set; }
        [Required]
        public int productId { get; set; }
    }
}
