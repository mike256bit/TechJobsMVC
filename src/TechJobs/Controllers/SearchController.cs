using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;


namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.error = "";
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchTerm != null && searchType.ToLower() != "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
            }
            else if (searchTerm != null)
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
            }
            else
            {
                ViewBag.error = "Please provide a search term.";
            }
            
            ViewBag.columns = ListController.columnChoices;
            return View("Index");
        }

    }
}
