using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShitoRyuSatokia.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Services;
using ShitoRyuSatokia.Models.MicroModel;

namespace ShitoRyuSatokia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            AdminViewModel viewModel = new AdminViewModel();
            UserDatabase userDatabase = new UserDatabase();

            var list = await userDatabase.GetAllDojos();
            var listN = await userDatabase.GetAllNews();

            ViewBag.DojoListing = list;
            ViewBag.NewsListing = listN;
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Galary()
        {
            return View();
        }

        public async Task<ActionResult> Intro()
        {
            AdminViewModel viewModel = new AdminViewModel(false);

            
            UserDatabase userDatabase = new UserDatabase();

            var list = await userDatabase.GetAllDojos();
            var listN = await userDatabase.GetAllNews();

            ViewBag.DojoListing = list;
            ViewBag.NewsListing = listN;


            return View(viewModel);
        } 
        public IActionResult Image()
        {
            AdminViewModel viewModel = new AdminViewModel();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SelectNews(string newsid)
        {
            UserDatabase userDatabase = new UserDatabase();
            AdminViewModel viewModel = new AdminViewModel(newsid, true);
            var listN = await userDatabase.GetAllNews();


            News news = new News();
            

            foreach(var i in listN)
            {
                if(i.Id == newsid)
                {
                    news = i;
                }
            }

            ViewBag.SelectedNews = news;


            


            return View("Image",viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
