using IntexMummy11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Controllers
{
    public class SiteController : Controller
    {

        public IActionResult BurialList()
        {
            return View();
        }

        public IActionResult BurialPredictions()
        {
            return View();
        }

        public IActionResult BurialInsights()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
