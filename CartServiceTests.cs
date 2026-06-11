using Joy_Delivery.Dtos;
using Joy_Delivery.Models;
using Joy_Delivery.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joy_DeliveryTests.Services
{
    [TestClass]
    public class CartServiceTests
    {
        private CartService _cartService = null!;

        [TestInitialize]
        public void Setup()
        {
            _cartService = new CartService(
                new ProductService(),
                new UserService());
        }

        [TestMethod]
        public void GetCartForUser_ValidUser_ReturnsCart()
        {
            var cart = _cartService.GetCartForUser("user101");

            Assert.IsNotNull(cart);
            Assert.AreEqual("cart101", cart.Id);
        }

        [TestMethod]
        public void GetCartForUser_InvalidUser_ReturnsNull()
        {
            var cart = _cartService.GetCartForUser("invalid");

            Assert.IsNull(cart);
        }

        [TestMethod]
        public void AddProductToCartForUser_ValidRequest_AddsProduct()
        {
            var request = new AddProductRequest
            {
                UserId = "user101",
                ProductId = "product101",
                OutletId = "store101"
            };

            var result = _cartService.AddProductToCartForUser(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("product101", result.Product.Id);
            Assert.AreEqual(1, result.Cart.Products.Count);
        }

        [TestMethod]
        public void AddProductToCartForUser_ReturnsCorrectSellingPrice()
        {
            var request = new AddProductRequest
            {
                UserId = "user101",
                ProductId = "product101",
                OutletId = "store101"
            };

            var result = _cartService.AddProductToCartForUser(request);

            var product = (GroceryProduct)result.Product;

            Assert.AreEqual(
                product.SellingPrice,
                result.SellingPrice);
        }

        // ==========================
        // Additional TDD Tests
        // ==========================
        [TestMethod]
        public void AddProductToCart_InvalidUser_ShouldThrow()
        {
            var request = new AddProductRequest
            {
                UserId = "invalid",
                ProductId = "product101",
                OutletId = "store101"
            };

            Assert.ThrowsException<InvalidOperationException>(
                () => _cartService.AddProductToCartForUser(request));
        }

        [TestMethod]
        public void AddProductToCart_InvalidProduct_ShouldThrow()
        {
            var request = new AddProductRequest
            {
                UserId = "user101",
                ProductId = "invalid",
                OutletId = "store101"
            };

            Assert.ThrowsException<InvalidOperationException>(
                () => _cartService.AddProductToCartForUser(request));
        }

        [TestMethod]
        public void AddProductToCart_NullRequest_ShouldThrow()
        {
            Assert.ThrowsException<NullReferenceException>(
                () => _cartService.AddProductToCartForUser(null!));
        }
    }
}