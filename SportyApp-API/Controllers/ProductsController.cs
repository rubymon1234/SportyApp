using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportyApp.Data;
using SportyApp.DTO.Products;
using SportyApp.Models;
using SportyApp.Models.Repository;
using SportyApp.Models.Repository.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;

namespace SportyApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductsRepository _productsRepository;
        private IMapper _mapper;

        public ProductsController(UserManager<AppUser> userManager,IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Products>> postProducts([FromBody] CreateProductDto productDTO)
        {
            //var result = _dbContext.Products.AsQueryable().Where(x => x.Title.ToLower().Trim() == 
            //productDTO.Title.ToLower().Trim()).Any();

            if (_productsRepository.isRecordExist(productDTO.Title))
            {
                return Conflict("Products Already Exists in Database.");
            }
            //Products product = new Products();
            //product.Title = productDTO.Title;
            //product.Description = productDTO.Description;
            //product.Image = productDTO.Image;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            productDTO.CreatedBy = userId;
            var product = _mapper.Map<Products>(productDTO);
            await _productsRepository.Create(product);
            //_dbContext.Products.Add(product);
            //_dbContext.SaveChanges();
            return CreatedAtAction("getProductById", new { id = product.Id }, product);
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<Products>>> getAllProducts()
        {
            var products = await _productsRepository.GetAll();
            var productDto = _mapper.Map<List<ProductListDto>>(products);
            if (products ==null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Products>> getProductById(int id)
        {
            var products = await _productsRepository.GetFindById(id);
            var productFindByDto = _mapper.Map<ProductFindByDto>(products);

            if (products ==null)
            {
                return NotFound();
            }
            return Ok(productFindByDto);
        }
        [HttpPut]
        public async Task<ActionResult<Products>> putUpdateProducts([FromBody] Products product)
        {
             await _productsRepository.UpdateById(product);
            //_dbContext.SaveChanges();
            return Ok(product);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> getDeleteById(int id)
        {
           // var product = _dbContext.Products.Find(id);
            var product = await _productsRepository.GetFindById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productsRepository.Delete(product);
            //_dbContext.Products.Remove(products);
            //_dbContext.SaveChanges();
            return Ok();
        }
    }
}
