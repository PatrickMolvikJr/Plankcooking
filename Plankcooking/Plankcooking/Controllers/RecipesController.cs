using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Plankcooking.Controllers
{
    public class RecipesController : Controller
    {
        [Route("Recipes")]
        public IActionResult Index()
        {
            return View();
        }
    }
}