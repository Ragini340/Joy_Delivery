using Joy_Delivery.Dtos;
using Joy_Delivery.Models;
using Joy_Delivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Joy_Delivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController(CartService cartService) : ControllerBase
    {
        [HttpPost("product")]
        public ActionResult<CartProductInfo> AddProductToCart([FromBody] AddProductRequest addProductRequest)
        {
            var result = cartService.AddProductToCartForUser(addProductRequest);

            return Ok(result);
        }

        [HttpGet("view")]
        public ActionResult<Cart> ViewCart([FromQuery(Name = "userId")] string userId)
        {
            var cart = cartService.GetCartForUser(userId);

            return Ok(cart);
        }
    }
}