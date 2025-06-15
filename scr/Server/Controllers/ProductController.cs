using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Services;
using Shared;

namespace Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductsService _productsServise;

        public ProductController(ProductsService productsService)
        {
            _productsServise = productsService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductEntity product)
        {
            _productsServise.AddProduct(product);
            return Ok();
        }

        //[HttpGet]
        //public IActionResult GetAllProducts()
        //{
        //    var allProducts = _productsServise.GetAllProducts();
        //    return Ok(allProducts);
        //}

        //[HttpGet("get-products-containing/{substring}")]
        //public IActionResult GetProductsContaining(string substring)
        //{
        //    var products = _productsServise.GetProductsContaining(substring);
        //    return Ok(products);
        //}

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productsServise.GetProductById(id);
            return Ok(product);
        }

        //[HttpGet("get-products-by-page")]
        //public IActionResult GetProductsByPage(int page = 1, int pageSize = 10)
        //{
        //    var products = _productsServise.GetProductsByPage(page, pageSize);
        //    return Ok(products);
        //}

        [HttpGet]
        public IActionResult GetProductsByPage([FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productsServise.GetProducts(search, page, pageSize);
            return Ok(products);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById(Guid id, [FromBody]ProductEntity product)
        {
            var updatedProduct = _productsServise.UpdateProductById(id, product);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            _productsServise.DeledeProductById(id);
            return Ok();
        }

        [HttpGet("{id}/comments")]
        public IActionResult GetAllProductComments(Guid id)
        {
            var comments = _productsServise.GetAllProductComments(id);
            return Ok(comments);
        }
    }
}
