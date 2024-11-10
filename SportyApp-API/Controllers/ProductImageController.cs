using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportyApp.Data;
using SportyApp.DTO.ProductImages;
using SportyApp.DTO.Products;
using SportyApp.Models;

namespace SportyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private IMapper _mapper;

        public ProductImageController(ApplicationDbContext bbcontext, IMapper mapper)
        {
            _dbContext = bbcontext;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult InsertImage([FromBody] ProductImageDto ProductImageDto)
        {
            ProductImages productImage = new ProductImages();
            productImage.path = ProductImageDto.path;
            productImage.productId = ProductImageDto.productId;
            var productim = _mapper.Map<ProductImages>(productImage);

            _dbContext.ProductImages.Add(productim);
            _dbContext.SaveChanges();

            return Ok(ProductImageDto);
        }
        [HttpGet]
        public ActionResult getProductImage()
        {
            var imagesList = _dbContext.ProductImages.ToList();

            var productDto = _mapper.Map<List<ProductImageListDto>>(imagesList);
            if (productDto == null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }
    }
}
