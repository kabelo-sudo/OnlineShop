public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } // Created, Processing, Shipped, Delivered
}
