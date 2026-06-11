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
            if (user is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var cart = FetchCartForUser(user);
            if (cart is null)
            {
                throw new InvalidOperationException("Cart not found.");
            }

            var product = productService.GetProduct(addProductRequest.ProductId, addProductRequest.OutletId);
            if (product is null)
            {
                throw new InvalidOperationException("Product not found.");
            }

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