using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Plankcooking.Controllers
{
    public class CookieController : Controller
    {


        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["plankCookingGuid"];

            string cookieValueFromReq = Request.Cookies["plankCookingGuid"];
            return View();
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
    }
}