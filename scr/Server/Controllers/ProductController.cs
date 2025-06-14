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

    }
}
