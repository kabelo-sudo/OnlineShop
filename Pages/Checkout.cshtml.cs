using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly ShopContext _context;

        public List<CartItem> CartItems { get; set; } = new();
        public decimal GrandTotal { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Address { get; set; }

        public CheckoutModel(ShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            LoadCart();
        }

        public IActionResult OnPost()
        {
            LoadCart();

            if (!CartItems.Any())
                return RedirectToPage("/Cart");

            // ? CLEAR CART (simulate order placed)
            _context.CartItems.RemoveRange(CartItems);
            _context.SaveChanges();

            return RedirectToPage("/OrderSuccess");
        }

        private void LoadCart()
        {
            CartItems = _context.CartItems
                .Include(c => c.Product)
                .ToList();

            GrandTotal = CartItems.Sum(c => c.Product.Price * c.Quantity);

            ViewData["CartCount"] = CartItems.Sum(c => c.Quantity);
        }
    }
}
