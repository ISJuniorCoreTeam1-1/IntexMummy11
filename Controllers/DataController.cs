﻿using IntexMummy11.Models;
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

        public IActionResult BurialList()
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