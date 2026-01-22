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

        // To show message if cart is empty
        public string Message { get; set; }

        public CheckoutModel(ShopContext context)
        {
            _context = context;
        }

        // ?? Block checkout if cart is empty
        public IActionResult OnGet()
        {
            LoadCart();

            if (!CartItems.Any())
            {
                Message = "Your cart is empty. Add products before checkout.";
                return Page(); // Stay on page, show message
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            LoadCart();

            if (!CartItems.Any())
            {
                Message = "Cannot place order. Your cart is empty!";
                return Page(); // Prevent order if no items
            }

            // ? Process order: clear cart
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
