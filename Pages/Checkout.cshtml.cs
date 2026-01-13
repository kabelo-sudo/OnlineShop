using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public string CustomerName { get; set; } = "";

        [BindProperty]
        public string CardNumber { get; set; } = "";

        public string Message { get; set; } = "";

        public void OnGet()
        {
            // Page load
        }

        public void OnPost()
        {
            // Fake payment logic
            Message = "Payment Successful! Thank you for your order.";
        }
    }
}
