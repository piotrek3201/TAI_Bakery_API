using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Model;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Tags("Products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        
        //GET: api/products/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await productRepository.GetAllProductsAsync();
        }

        //GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<Product> GetProductById(long id)
        {
            return await productRepository.GetProductByIdAsync(id);
        }

        //POST: api/products/add
        [HttpPost("add")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            bool createSuccesful = await productRepository.AddProductAsync(product);
            if (createSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/products/update
        [HttpPut("update")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            bool updateSuccesful = await productRepository.UpdateProductAsync(product);
            if (updateSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE: api/products/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            bool deleteSuccesful = await productRepository.DeleteProductAsync(id);
            if (deleteSuccesful)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
