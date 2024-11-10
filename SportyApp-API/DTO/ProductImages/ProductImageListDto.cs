using System.ComponentModel.DataAnnotations;

namespace SportyApp.DTO.ProductImages
{
    public class ProductImageListDto
    {
        public Guid Id { get; set; }
        public string path { get; set; }
        public int productId { get; set; }
    }
}
