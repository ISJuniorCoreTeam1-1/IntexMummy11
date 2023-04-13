using IntexMummy11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Components
{
    public class FilteringViewComponent: ViewComponent
    {
        private IBurialRepository repo { get; set; }

        public FilteringViewComponent(IBurialRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Selectedfilter = RouteData?.Values["Sex"];

            var sex = repo.Data
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x);
            return View(sex);
        }
    }
}
