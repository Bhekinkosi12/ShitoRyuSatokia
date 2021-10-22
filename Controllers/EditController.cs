using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models;

namespace ShitoRyuSatokia.Controllers
{
    public class EditController : Controller
    {
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


        [HttpPost]
        public IActionResult EditDojo(string DojoName)
        {
            AdminViewModel adminView = new AdminViewModel(DojoName);

            return View("Dojoview",adminView);
        }

    }
}
