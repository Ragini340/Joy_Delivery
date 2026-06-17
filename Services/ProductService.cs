using Joy_Delivery.Models;
using Joy_Delivery.Seed;

namespace Joy_Delivery.Services
{
    public class ProductService
    {
        private readonly List<GroceryProduct> _products = SeedData.GroceryProducts;

        public GroceryProduct? GetProduct(string productId, string outletId) =>
            _products.FirstOrDefault(p =>
                p.Id == productId && p.Store?.Id == outletId);

        public List<GroceryProduct> SearchProductsByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) {
                return [];
            }
            return _products.Where(p => p.Name != null && p.Name.Contains(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}