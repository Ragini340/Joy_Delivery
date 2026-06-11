using Joy_Delivery.Dtos;
using Joy_Delivery.Models;
using Joy_Delivery.Seed;

namespace Joy_Delivery.Services
{
    public class CartService(ProductService productService, UserService userService)
    {
        private readonly Dictionary<string, Cart> _userCarts = SeedData.CartForUsers;

        public CartProductInfo AddProductToCartForUser(AddProductRequest addProductRequest)
        {
            var user = userService.FetchUserById(addProductRequest.UserId);
            var cart = FetchCartForUser(user);
            var product = productService.GetProduct(addProductRequest.ProductId, addProductRequest.OutletId);

            cart.Products ??= [];

            cart.Products.Add(product);

            return new CartProductInfo(cart, product, product.SellingPrice);
        }

        public Cart? GetCartForUser(string userId) =>
            _userCarts.GetValueOrDefault(userId);

        private Cart? FetchCartForUser(User user)
        {
            return _userCarts.GetValueOrDefault(user.Id);
        }
    }
}