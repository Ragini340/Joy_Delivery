using Joy_Delivery.Controllers;
using Joy_Delivery.Models;
using Joy_Delivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Joy_Delivery.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private ProductController _controller = null!;
        private ProductService _productService = null!;

        [TestInitialize]
        public void Setup()
        {
            _productService = new ProductService();
            _controller = new ProductController(_productService);
        }

        [TestMethod]
        public void Search_ValidProductName_ReturnsOkResult()
        {
            // Arrange
            var productName = "Bread";

            // Act
            var result = _controller.Search(productName);

            // Assert
            Assert.IsInstanceOfType(
                result.Result,
                typeof(OkObjectResult));
        }

        [TestMethod]
        public void Search_ValidProductName_ReturnsMatchingProducts()
        {
            // Arrange
            var productName = "Bread";

            // Act
            var result = _controller.Search(productName);

            // Assert
            var okResult =
                result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var products =
                okResult.Value as List<GroceryProduct>;

            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(
                "Wheat Bread",
                products[0].Name);
        }

        [TestMethod]
        public void Search_InvalidProductName_ReturnsEmptyList()
        {
            // Arrange
            var productName = "Chocolate";

            // Act
            var result = _controller.Search(productName);

            // Assert
            var okResult =
                result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var products =
                okResult.Value as List<GroceryProduct>;

            Assert.IsNotNull(products);
            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void Search_PartialName_ReturnsMatchingProducts()
        {
            // Arrange
            var productName = "Bre";

            // Act
            var result = _controller.Search(productName);

            // Assert
            var okResult =
                result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var products =
                okResult.Value as List<GroceryProduct>;

            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod]
        public void Search_CaseInsensitiveName_ReturnsMatchingProducts()
        {
            // Arrange
            var productName = "bread";

            // Act
            var result = _controller.Search(productName);

            // Assert
            var okResult =
                result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var products =
                okResult.Value as List<GroceryProduct>;

            Assert.IsNotNull(products);
            Assert.AreEqual(1, products.Count);
        }
    }
}