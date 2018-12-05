using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Plankcooking.Controllers
{
    public class AboutController : Controller
    {
        [Route("About")]
        public IActionResult Index()
        {
            return View();
        }
    }
}