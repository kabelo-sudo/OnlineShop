using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Pages
{
    public class CartModel : PageModel
    {
        private readonly ShopContext _context;

        public List<CartItem> CartItems { get; set; }

        public CartModel(ShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CartItems = _context.CartItems
                .Include(c => c.Product)
                .ToList();
        }
    }
}
