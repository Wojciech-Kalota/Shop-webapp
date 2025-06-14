using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Services;
using Shared;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductsService _productsServise;

        public ProductController(ProductsService productsService)
        {
            _productsServise = productsService;
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody]ProductEntity product)
        {
            _productsServise.AddProduct(product);
            return Ok();
        }

        [HttpGet("get-all-products")]
        public IActionResult GetAllProducts()
        {
            var allProducts = _productsServise.GetAllProducts();
            return Ok(allProducts);
        }

        [HttpGet("get-product-by-id/{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productsServise.GetProductById(id);
            return Ok(product);
        }

        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProductById(Guid id, [FromBody]ProductEntity product)
        {
            var updatedProduct = _productsServise.UpdateProductById(id, product);
            return Ok(updatedProduct);
        }

        [HttpDelete("delete-product-by-id/{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            _productsServise.DeledeProductById(id);
            return Ok();
        }
    }
}
