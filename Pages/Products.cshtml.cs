using Microsoft.AspNetCore.Mvc;
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

        public List<Product> Products { get; set; }

        public ProductsModel(ShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Products = _context.Products.ToList();
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            var cartItem = _context.CartItems
                .FirstOrDefault(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }

            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
