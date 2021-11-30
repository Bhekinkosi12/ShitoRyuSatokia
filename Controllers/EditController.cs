using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models;
using ShitoRyuSatokia.Services;
using ShitoRyuSatokia.Models.MicroModel;
using Microsoft.Extensions.Hosting;

namespace ShitoRyuSatokia.Controllers
{
    public class EditController : Controller
    {

        public static string Newss;
        
        public IActionResult Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            return View(adminViewModel);
        }

        public IActionResult Dojoview(string DojoName)
        {
            AdminViewModel adminView = new AdminViewModel(DojoName);
            return View(adminView);
        }
        public IActionResult Newsview(string Newsid)
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditDojo(string DojoName)
        {
            
            AdminViewModel adminView = new AdminViewModel(DojoName);   

            return View("Dojoview",adminView.ReturnDojo());
        }

        [HttpPost]
        public IActionResult EditNews(string Newsid)
        {
            Newss = Newsid;
            AdminViewModel adminView = new AdminViewModel(Newsid, true);

            return View("Newsview", adminView.ReturnNews());
        }



        [HttpPost]
        public IActionResult UpdateDojo(Dojo dojo)
        {
            PostViewModel postViewModel = new PostViewModel();

            postViewModel.UpdateDojo(dojo);
           

            return View("Index");
                               
        }

        [HttpPost]
        public IActionResult UpdateNews(News news)
        {
            PostViewModel postViewModel = new PostViewModel();

            postViewModel.UpDateNews(news);

            return View("Index");

        }

    }
}
