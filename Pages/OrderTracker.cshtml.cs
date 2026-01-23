using Microsoft.AspNetCore.Mvc.RazorPages;

public class OrderTrackerModel : PageModel
{
    public Order Order { get; set; }

    public void OnGet()
    {
        // Demo data (later replace with DB)
        Order = new Order
        {
            Id = 1001,
            CustomerName = "John Doe",
            OrderDate = DateTime.Now,
            Status = "Processing"
        };
    }
}
