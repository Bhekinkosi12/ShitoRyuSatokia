using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShitoRyuSatokia.Models;
using System;
using System.Collections.ObjectModel;
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
        public async Task<ActionResult> Gallery()
        {
            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();
             var ite = await userDatabase.GetAllImages();

            ViewBag.Listing = ite;

            ViewBag.Close = "none";
            ImageList imageList = new ImageList()
            {
                ImageListing = ite,
                 SelecetedImage = new Images() {  URL = ""}
            };
            Images img = new Images()
            {
                ID = "",
                URL = ""
            };
            return View(imageList);
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
        public async Task<ActionResult> ToGallery()
        {
            return View("Gallery");
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

        [HttpPost]
        public async Task<ActionResult> OnOpenPop(string id)
        {
            ViewBag.Close = "initial";
            ViewBag.Img = id;

            Images img = new Images()
            {
                 ID = "",
                  URL = id
            };




            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();
            var ite = await userDatabase.GetAllImages();

            ImageList imageList = new ImageList()
            {
                ImageListing = ite,
                SelecetedImage = new Images() { URL = id }
            };





            return View("Gallery",imageList);
        }

        [HttpPost]
        public async Task<ActionResult> OnClosePop()
        {
            ViewBag.Close = "none";

            Images img = new Images()
            {
                ID = "",
                URL = ""
            };



            UserDatabase userDatabase = new UserDatabase();
            UserStorage userStorage = new UserStorage();
            var ite = await userDatabase.GetAllImages();

            ViewBag.Listing = ite;

            ViewBag.Close = "none";
            ImageList imageList = new ImageList()
            {
                ImageListing = ite,
                SelecetedImage = new Images() { URL = "" }
            };


            return View("Gallery",imageList);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
