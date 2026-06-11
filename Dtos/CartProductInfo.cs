using Joy_Delivery.Models;

namespace Joy_Delivery.Dtos
{
    public class CartProductInfo(Cart cart, Product product, float sellingPrice)
    {
        public Cart Cart { get; } = cart;
        public Product Product { get; } = product;
        public float SellingPrice { get; } = sellingPrice;
    }
}