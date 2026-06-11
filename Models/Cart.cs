namespace Joy_Delivery.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public Outlet? Outlet { get; set; }
        public List<GroceryProduct> Products { get; set; } = [];
        public User? User { get; set; }
    }
}