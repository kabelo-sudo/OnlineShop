namespace OnlineShop.Models
{
    public class CartItem
    {
        public int Id { get; set; } // optional, only if storing in DB
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public string ImageUrl { get; set; } = "";
    }
}
