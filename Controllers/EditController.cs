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

        public IActionResult Dojoview()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Editdojo(string id)
        {
            return View();
        }

    }
}
