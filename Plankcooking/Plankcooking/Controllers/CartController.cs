using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plankcooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Plankcooking.Controllers
{
    public class CartController : Controller
    {
        private readonly Pmolvik_w17Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(Pmolvik_w17Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetCookie(string key)
        {
            return Request.Cookies[key];
        }

        public void SetCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = DateTime.Now.AddDays(1);

            Response.Cookies.Append(key, value, option);
        }

        public IActionResult Index()
        {
            return Redirect("/Cart/Cart");

        }
        public async Task<IActionResult> Cart()
        {
            Guid guid = Guid.NewGuid();
            if (GetCookie("plankCookingGuid") != null)
            {
                guid = Guid.Parse(GetCookie("plankCookingGuid"));
            }
            else
            {
                SetCookie("plankCookingGuid", guid.ToString());
                return View("EmptyCart");
            }

            OrderCart orderCart = await _context.OrderCarts.FirstOrDefaultAsync(u => u.UniqueIdentifier == guid);

            CartViewModel CartViewModel = new CartViewModel
            {
                OrderCartId = orderCart.OrderCartId,
                OrderItems = await _context.OrderItems.Where(o => o.OrderCartId == orderCart.OrderCartId).ToListAsync(),
                Products = await _context.Products.ToListAsync()
            };
            return View(CartViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems
                .SingleOrDefaultAsync(m => m.OrderItemId == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Receipt()        
        {                                       
            return View();
        }
    }
}
