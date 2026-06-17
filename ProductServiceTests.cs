using Joy_Delivery.Services;

namespace Joi_Delivery.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
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