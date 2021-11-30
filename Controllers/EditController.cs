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

            var item = adminView.ReturnDojo();

            item.IsNew = "false";


            return View("Dojoview",item);
        }

        [HttpPost]
        public IActionResult EditNews(string Newsid)
        {
            Newss = Newsid;
            AdminViewModel adminView = new AdminViewModel(Newsid, true);

            var item = adminView.ReturnNews();

            item.IsNew = "false";

            return View("Newsview", item);
        }


        [HttpPost]
        public IActionResult AddNews()
        {
            News news = new News();
            news.IsNew = "true";
            news.Id = Guid.NewGuid().ToString();
            return View("Newsview", news);

        }

        [HttpPost]
        public IActionResult AddDojo()
        {

            Dojo dojo = new Dojo();

            dojo.IsNew = "true";
            dojo.ID = Guid.NewGuid().ToString();

            return View("Dojoview", dojo);
        }






        [HttpPost]
        public IActionResult UpdateDojo(Dojo dojo)
        {
            PostViewModel postViewModel = new PostViewModel();

            if(dojo.IsNew == "true")
            {
                postViewModel.AddDojo(dojo);
            }
            else
            {

            postViewModel.UpdateDojo(dojo);
            }

           

            return View("Index");
                               
        }

        [HttpPost]
        public IActionResult UpdateNews(News news)
        {
            PostViewModel postViewModel = new PostViewModel();
            if(news.IsNew == "true")
            {
                postViewModel.AddNews(news);
            }
            else
            {
            postViewModel.UpDateNews(news);

            }


            return View("Index");

        }

    }
}
