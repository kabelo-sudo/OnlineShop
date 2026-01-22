using Microsoft.AspNetCore.Mvc;
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

        public List<CartItem> CartItems { get; set; } = new();
        public int TotalQuantity { get; set; }
        public decimal GrandTotal { get; set; }

        public CartModel(ShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CartItems = _context.CartItems
                .Include(c => c.Product)
                .ToList();

            TotalQuantity = CartItems.Sum(c => c.Quantity);
            GrandTotal = CartItems.Sum(c => c.Product.Price * c.Quantity);

            ViewData["CartCount"] = TotalQuantity;
        }

        // ? REMOVE ITEM FROM CART
        public IActionResult OnPostRemove(int id)
        {
            var item = _context.CartItems.FirstOrDefault(c => c.Id == id);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
