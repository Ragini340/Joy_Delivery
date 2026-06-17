using Joy_Delivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Joy_Delivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(ProductService productService) : ControllerBase
    {
        [HttpGet("search")]
        public ActionResult<List<Models.GroceryProduct>> Search([FromQuery] string name)
        {
            var products = productService.SearchProductsByName(name);
            return Ok(products);
        }

    }
}