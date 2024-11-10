using System.ComponentModel.DataAnnotations;

namespace SportyApp.DTO.Products
{
    public class CreateProductDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; }

        public string CreatedBy { get; set; }
    }
}
