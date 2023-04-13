using IntexMummy11.Models;
using IntexMummy11.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IntexMummy11.Controllers
{
    public class DataController : Controller
    {
        private IBurialRepository repo;

        public DataController(IBurialRepository temp)
        {
            repo = temp;
        }

        public IActionResult BurialList(string sex, int pageNum=1)
        {
            int pageSize = 40;
            var x = new MinitableViewModel
            {
                Data = repo.Data
                .Where(s=> s.Sex == sex || sex==null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    (sex == null ? 
                    repo.Data.Count() :
                    repo.Data.Where(x => x.Sex == sex).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
            
        }

        public IActionResult BurialPredictions()
        {
            return View();
        }

        public IActionResult BurialInsights()
        {
            var x = new BurialViewModel
            {
                Burials = repo.Burials
                /*.Where(b => b.Category == catergoryName || catergoryName == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)*/
            };
            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}