using IntexMummy11.Data;
using IntexMummy11.Models;
using IntexMummy11.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult BurialList(int pageNum=1)
        {
            int pageSize = 50;
            var x = new MinitableViewModel
            {
                Data = repo.Data
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    repo.Data.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
            
        }


        [HttpPost]
        public IActionResult BurialList(MinitableViewModel mtvm, int pageNum = 1)
        {
            int pageSize = 50;
            
            var x = new MinitableViewModel
            {
                Data = repo.Data
                .Where(s => s.Sex == mtvm.SexFilter || mtvm.SexFilter == null)
                .Where(a => a.Ageatdeath == mtvm.AgeFilter || mtvm.AgeFilter == null)
                .Where(c => c.ColorValue.Contains("/" + mtvm.TextileColorFilter + "/") || mtvm.TextileColorFilter == null)
                .Where(dmin => Convert.ToDecimal(dmin.Depth) >= Convert.ToDecimal(mtvm.BurialDepthFilterMin))
                .Where(dmax => Convert.ToDecimal(dmax.Depth) <= Convert.ToDecimal(mtvm.BurialDepthFilterMax))
                .Where(hd => hd.Headdirection == mtvm.HeadDirectionFilter || mtvm.HeadDirectionFilter == null)
                .Where(ts => ts.TextilefunctionValue.Contains("/" + mtvm.TextileStructureFilter + "/") || mtvm.TextileStructureFilter == null)
                .Where(tf => tf.TextilefunctionValue.Contains("/" + mtvm.TextileFunctionFilter + "/") || mtvm.TextileFunctionFilter == null)
                .Where(hc => hc.Haircolor == mtvm.HairColorFilter || mtvm.HairColorFilter == null)
                .Where(bw => bw.Wrapping == mtvm.BurialWrappingFilter || mtvm.BurialWrappingFilter == null)
                .Where(es => es.TextilefunctionValue.Contains("/" + mtvm.EstimatedStatureFilter + "/") || mtvm.EstimatedStatureFilter == null)
                .Where(fb => fb.Facebundles == mtvm.FaceBundleFilter || mtvm.FaceBundleFilter == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    (mtvm.SexFilter == null && mtvm.AgeFilter == null && mtvm.FaceBundleFilter == null && mtvm.TextileColorFilter == null && mtvm.HeadDirectionFilter == null && mtvm.TextileStructureFilter == null && mtvm.TextileFunctionFilter == null && mtvm.HairColorFilter == null && mtvm.BurialWrappingFilter == null && mtvm.EstimatedStatureFilter == null ?
                    repo.Data.Count() :
                    repo.Data.Where(x => x.Sex == mtvm.SexFilter)
                    .Where(a => a.Ageatdeath == mtvm.AgeFilter)
                    .Where(c => c.ColorValue.Contains("/"+ mtvm.TextileColorFilter + "/"))
                    .Where(dmin => Convert.ToDecimal(dmin.Depth) >= Convert.ToDecimal(mtvm.BurialDepthFilterMin))
                    .Where(dmax => Convert.ToDecimal(dmax.Depth) <= Convert.ToDecimal(mtvm.BurialDepthFilterMax))
                    .Where(hd => hd.Headdirection == mtvm.HeadDirectionFilter)
                    .Where(ts => ts.TextilefunctionValue.Contains("/" + mtvm.TextileStructureFilter + "/"))
                    .Where(tf => tf.TextilefunctionValue.Contains("/" + mtvm.TextileFunctionFilter + "/"))
                    .Where(hc => hc.Haircolor == mtvm.HairColorFilter)
                    .Where(bw => bw.Wrapping == mtvm.BurialWrappingFilter)
                    .Where(tf => tf.TextilefunctionValue.Contains("/" + mtvm.EstimatedStatureFilter + "/"))
                    .Where(fb => fb.Facebundles == mtvm.FaceBundleFilter)
                    .Count()),
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

        //Creating Burial Main record
        [HttpGet]
        public IActionResult CreateBurialMain()
        {
            //Create a new BurialMain record and pass it to  the view to add it

            return View(new Burialmain());

        }


        [HttpPost]
        public IActionResult CreateBurialMain(Burialmain newlyCreatedBurialMain)
        {
            //Create a new BurialMain record and pass it to  the view to add it

            //Could validate some data here with a post or something.
            if (ModelState.IsValid)
            {

                //Find the next id
                repo.Burials.Select(col => col.Id).Max();
                Burialmain lastRecord = repo.Burials.OrderByDescending(col => col.Id).FirstOrDefault();
                long nextID = lastRecord.Id + 1;


                // Set property values from the newlyCreatedBurialMain parameter
                Burialmain addme = new Burialmain
                {

                    Id = nextID,
                    Squarenorthsouth = newlyCreatedBurialMain.Squarenorthsouth,
                    Headdirection = newlyCreatedBurialMain.Headdirection,
                    Sex = newlyCreatedBurialMain.Sex,
                    Northsouth = newlyCreatedBurialMain.Northsouth,
                    Depth = newlyCreatedBurialMain.Depth,
                    Eastwest = newlyCreatedBurialMain.Eastwest,
                    Adultsubadult = newlyCreatedBurialMain.Adultsubadult,
                    Facebundles = newlyCreatedBurialMain.Facebundles,
                    Southtohead = newlyCreatedBurialMain.Southtohead,
                    Preservation = newlyCreatedBurialMain.Preservation,
                    Fieldbookpage = newlyCreatedBurialMain.Fieldbookpage,
                    Squareeastwest = newlyCreatedBurialMain.Squareeastwest,
                    Goods = newlyCreatedBurialMain.Goods,
                    Text = newlyCreatedBurialMain.Text,
                    Wrapping = newlyCreatedBurialMain.Wrapping,
                    Haircolor = newlyCreatedBurialMain.Haircolor,
                    Westtohead = newlyCreatedBurialMain.Westtohead,
                    Samplescollected = newlyCreatedBurialMain.Samplescollected,
                    Area = newlyCreatedBurialMain.Area,
                    Burialid = newlyCreatedBurialMain.Burialid, //May be null
                    Length = newlyCreatedBurialMain.Length,
                    Burialnumber = newlyCreatedBurialMain.Burialnumber,
                    Dataexpertinitials = newlyCreatedBurialMain.Dataexpertinitials,
                    Westtofeet = newlyCreatedBurialMain.Westtofeet,
                    Ageatdeath = newlyCreatedBurialMain.Ageatdeath,
                    Southtofeet = newlyCreatedBurialMain.Southtofeet,
                    Excavationrecorder = newlyCreatedBurialMain.Excavationrecorder,
                    Photos = newlyCreatedBurialMain.Photos,
                    Hair = newlyCreatedBurialMain.Hair,
                    Burialmaterials = newlyCreatedBurialMain.Burialmaterials,
                    Dateofexcavation = newlyCreatedBurialMain.Dateofexcavation, //Datetime type // may be null
                    Fieldbookexcavationyear = newlyCreatedBurialMain.Fieldbookexcavationyear,
                    Clusternumber = newlyCreatedBurialMain.Clusternumber,
                    Shaftnumber = newlyCreatedBurialMain.Shaftnumber
                };


                // Add the new object to the database context
                repo.Add(addme);
                // Save the changes to the database
                repo.Save();
                


            }
            int pageNum = 1;
            int pageSize = 50;
            var x = new MinitableViewModel
            {
                Data = repo.Data
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    repo.Data.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };






            return View("BurialList",x);

        }


        [HttpGet]
        public IActionResult Edit(long burialmainid)
        {
            // Retrieve the BurialMain record to be edited
            var burialMain = repo.Burials.Single(b => b.Id == burialmainid);
            if (burialMain == null)
            {
                // Handle case where record is not found
                return NotFound();
            }

            // Pass the BurialMain object to the CreateBurialMain view as the model
            return View("CreateBurialMain", burialMain);
        }

        //[HttpPost]
        //public IActionResult Edit(Burialmain yuh)
        //{
        //    using (var dbContext = new ebdbContext())
        //    {
        //        dbContext.Update(yuh);
        //        dbContext.SaveChanges();
        //    }
        //    return View("BurialList"); 
        //}


        [HttpPost]
        public IActionResult Edit(Burialmain yuh)
        {

            repo.Add(yuh);
            repo.Save();
            
            return View("BurialList");
        }


        
        [HttpPost]
        public IActionResult BurialDetails(long BurialIDForDescription)
        {
            var x = new MinitableViewModel
            {
                Data = repo.Data
                .Where(x => x.Burialmainid == BurialIDForDescription)
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