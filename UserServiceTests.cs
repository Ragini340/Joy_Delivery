using Joy_Delivery.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joy_Delivery.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService = null!;

        [TestInitialize]
        public void Setup()
        {
            _userService = new UserService();
        }

        [TestMethod]
        public void FetchUserById_ValidUser_ReturnsUser()
        {
            // Arrange
            var userId = "user101";

            // Act
            var result = _userService.FetchUserById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.Id);
        }

        [TestMethod]
        public void FetchUserById_InvalidUser_ReturnsNull()
        {
            // Act
            var result = _userService.FetchUserById("invalid-user");

            // Assert
            Assert.IsNull(result);
        }
    }
}