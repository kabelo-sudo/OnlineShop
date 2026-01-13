using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ShopContext _context;

        public List<Product> Products { get; set; } = new();

        // Constructor: gets database connection
        public ProductsModel(ShopContext context)
        {
            _context = context;
        }

        // Runs when page loads
        public void OnGet()
        {
            Products = _context.Products.ToList();
        }
    }
}
