using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolutionTestTaskFromMansur.Helpers;
using SolutionTestTaskFromMansur.Models;
using SolutionTestTaskFromMansur.Models.DataBaseModels;
using SolutionTestTaskFromMansur.Models.DataBaseModels.EntityModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SolutionTestTaskFromMansur.Controllers
{
    public class HomeController : Controller
    {
        private const int Person_Records_Col_count = 11;
        private readonly ILogger<HomeController> _logger;
        private readonly TestTaskDbContext _context;
        public HomeController(ILogger<HomeController> logger, TestTaskDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Index(int page = 1, string sort = "PayrolNumber", string sortdir = "asc", string search = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = PersonalRecors(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        private List<PersonalRecord> PersonalRecors(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            var allPersonalRecords = _context.PersonalRecords.ToList();
            if (search == null) search = string.Empty;
            var query = (from a in allPersonalRecords
                         where
                                 a.PayrolNumber.Contains(search) ||
                                 a.Forenames.Contains(search) ||
                                 a.Surname.Contains(search)
                         select a
                         );
            totalRecord = query.Count();
            query = query.AsQueryable().OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                query = query.Skip(skip).Take(pageSize);
            }
            return query.ToList();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult FileToDbConvertor(IFormFile postedFile)
        {
            TempData["errorMessage"] = string.Empty;

            if (postedFile.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(postedFile.OpenReadStream()))
                {
                    var addedRowsCount = 0;
                    var headers = sreader.ReadLine().Split(',');     //Getting all headers from csv file
                    if (headers.Length < Person_Records_Col_count)
                    {
                        TempData["errorMessage"] = "Error in columns count matching!";

                    }
                    else

                        while (!sreader.EndOfStream)
                        {
                            var rowData = sreader.ReadLine().Split(',');
                            var pRecord = rowData.ToPersonalRecord();
                            if (pRecord != null)
                            {
                                _context.PersonalRecords.Add(pRecord);
                                addedRowsCount++;
                            }
                        }
                    TempData["addedRowsCount"] = addedRowsCount;
                    _context.SaveChanges();

                }
            }
            else TempData["errorMessage"] = "File extension error!";

            var allRecords = _context.PersonalRecords.ToList();
            return RedirectToAction("Index", "Home");
        }

    }
}
