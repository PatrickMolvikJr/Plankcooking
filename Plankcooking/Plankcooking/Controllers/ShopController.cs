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
    public class ShopController : Controller
    {
        private readonly Pmolvik_w17Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopController(Pmolvik_w17Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }


        // GET: /<controller>/
        [Route("Shop/Products")]
        public IActionResult Index()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["plankCookingGuid"];

            string cookieValueFromReq = Request.Cookies["plankCookingGuid"];
            return View();
        }

        public async Task<IActionResult> SpiceRubs()
        {
            var AddOrderItem = new AddOrderItem
            {
                Products = await _context.Products.Where(c => c.CategoryId == 1).ToListAsync(),
                ProductId = 0,
                Qty = 0
            };
            return View(AddOrderItem);
          
        }
        public async Task<IActionResult> Cookbooks()
        {
            var AddOrderItem = new AddOrderItem
            {
                Products = await _context.Products.Where(c => c.CategoryId == 2).ToListAsync(),
                ProductId = 0,
                Qty = 0
            };
            return View(AddOrderItem);
        }
        public async Task<IActionResult> BakingPlanks()
        {
            var AddOrderItem = new AddOrderItem
            {
                Products = await _context.Products.Where(c => c.CategoryId == 3).ToListAsync(),
                ProductId = 0,
                Qty = 0
            };
            return View(AddOrderItem);
        }
        public async Task<IActionResult> BBQPlanks()
        {
            var AddOrderItem = new AddOrderItem
            {
                Products = await _context.Products.Where(c => c.CategoryId == 4).ToListAsync(),
                ProductId = 0,
                Qty = 0
            };
            return View(AddOrderItem);
        }
        public async Task<IActionResult> NutDriver()
        {
            var AddOrderItem = new AddOrderItem
            {
                Products = await _context.Products.Where(c => c.CategoryId == 5).ToListAsync(),
                ProductId = 0,
                Qty = 0
            };
            return View(AddOrderItem);
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

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, Int16 qty) 
        {
            Guid thisGuid = Guid.NewGuid();

            string cookie = GetCookie("plankCookingGuid");
            if (cookie == null)
            {
                SetCookie("plankCookingGuid", thisGuid.ToString());
                cookie = thisGuid.ToString();
            }

           
            thisGuid = Guid.Parse(cookie);
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(a => a.ProductId == productId);

                string catagoryRoute;
                if (product.CategoryId == 1)
                {
                    catagoryRoute = "SpiceRubs";
                }
                else if (product.CategoryId == 2)
                {
                    catagoryRoute = "Cookbooks";
                }
                else if (product.CategoryId == 3)
                {
                    catagoryRoute = "BakingPlanks";
                }
                else if (product.CategoryId == 4)
                {
                    catagoryRoute = "BBQPlanks";
                }
                else if (product.CategoryId == 5)
                {
                    catagoryRoute = "NutDriver";
                }
                else
                {
                    return Ok("CategoryId not found" + product.CategoryId);
                }


                var orderCart = await _context.OrderCarts.FirstOrDefaultAsync(a => a.UniqueIdentifier.ToString() == cookie);

                if (orderCart == null)
                {
                  orderCart = new OrderCart
                  {
                      UniqueIdentifier = Guid.Parse(cookie),
                      WebsiteId = 1
                  };
                    _context.Add(orderCart);
                }

                await _context.SaveChangesAsync();

                orderCart = await _context.OrderCarts.FirstOrDefaultAsync(a => a.UniqueIdentifier.ToString() == cookie);


                OrderItem orderItemToAdd = new OrderItem  //It took me a while to realize that I needed to add the orderItem AFTER saving the orderCart to the Database,
                {                                         //so that this orderItem had an orderCart in the DB to be assigned to... DUUUUUUUUUUUH!
                    ProductId = product.ProductId,
                    OrderCartId = orderCart.OrderCartId,
                    Qty = qty
                };

                _context.Add(orderItemToAdd);     
                await _context.SaveChangesAsync();
                return RedirectToAction(catagoryRoute);

            }
            catch (Exception err)
            {
                return BadRequest(err + " >>> " + cookie);
            }

        }
    }
}
