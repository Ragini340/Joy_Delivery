using Joy_Delivery.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joy_Delivery.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private ProductService _productService = null!;

        [TestInitialize]
        public void Setup()
        {
            _productService = new ProductService();
        }

        [TestMethod]
        public void GetProduct_ValidProductAndOutlet_ReturnsProduct()
        {
            // Arrange
            var productId = "product101";
            var outletId = "store101";

            // Act
            var result = _productService.GetProduct(productId, outletId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(productId, result.Id);
            Assert.AreEqual(outletId, result.Store?.Id);
        }

        [TestMethod]
        public void GetProduct_InvalidProduct_ReturnsNull()
        {
            // Act
            var result = _productService.GetProduct(
                "invalid-product",
                "store101");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetProduct_InvalidOutlet_ReturnsNull()
        {
            // Act
            var result = _productService.GetProduct(
                "product101",
                "invalid-store");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchProductsByName_ExistingName_ReturnsProducts()
        {
            // Arrange
            var service = new ProductService();

            // Act
            var result =
                service.SearchProductsByName("Bread");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(
                "Wheat Bread",
                result[0].Name);
        }


        [TestMethod]
        public void SearchProductsByName_InvalidName_ReturnsEmpty()
        {
            var service = new ProductService();

            var result =
                service.SearchProductsByName("Chocolate");

            Assert.AreEqual(0, result.Count);
        }
    }
}