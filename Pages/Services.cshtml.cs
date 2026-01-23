using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Pages
{
    public class ServicesModel : PageModel
    {
        private readonly ILogger<ServicesModel> _logger;

        public ServicesModel(ILogger<ServicesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
