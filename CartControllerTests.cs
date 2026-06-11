using Joy_Delivery.Controllers;
using Joy_Delivery.Dtos;
using Joy_Delivery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joy_DeliveryTests.Controllers
{
    [TestClass]
    public class CartControllerTests
    {
        private CartController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            var cartService = new CartService(
                new ProductService(),
                new UserService());

            _controller = new CartController(cartService);
        }

        [TestMethod]
        public void ViewCart_ReturnsOkObjectResult()
        {
            var result = _controller.ViewCart("user101");

            Assert.IsInstanceOfType(
                result.Result,
                typeof(OkObjectResult));

            var okResult = (OkObjectResult)result.Result!;

            Assert.IsNotNull(okResult.Value);
        }

        [TestMethod]
        public void ViewCart_ReturnsCartForUser()
        {
            var result = _controller.ViewCart("user101");

            var okResult = (OkObjectResult)result.Result!;

            dynamic cart = okResult.Value!;

            Assert.AreEqual("cart101", cart.Id);
        }

        [TestMethod]
        public void AddProductToCart_ReturnsOkObjectResult()
        {
            var request = new AddProductRequest
            {
                UserId = "user101",
                ProductId = "product101",
                OutletId = "store101"
            };

            var result = _controller.AddProductToCart(request);

            Assert.IsInstanceOfType(
                result.Result,
                typeof(OkObjectResult));
        }

        [TestMethod]
        public void AddProductToCart_ReturnsCartProductInfo()
        {
            var request = new AddProductRequest
            {
                UserId = "user101",
                ProductId = "product101",
                OutletId = "store101"
            };

            var result = _controller.AddProductToCart(request);

            var okResult = (OkObjectResult)result.Result!;

            Assert.IsNotNull(okResult.Value);
        }
    }
}