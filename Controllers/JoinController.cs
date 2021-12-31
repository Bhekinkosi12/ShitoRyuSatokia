using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models.MicroModel;
using ShitoRyuSatokia.Models;
using ShitoRyuSatokia.Services;

namespace ShitoRyuSatokia.Controllers
{
    public class JoinController : Controller
    {
        public IActionResult Index()
        {

            Dojo dojo = new Dojo();
            return View(dojo);
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Subform(Dojo dojo)
        {

            JoinViewModel joinView = new JoinViewModel();



            UserDatabase userDatabase = new UserDatabase();
            var IsDataSent = await userDatabase.AddRequest(dojo);

            //  joinView.SetData(dojo);


            if (IsDataSent)
            {

            return View("Success");
            }
            else
            {
                return View("Index");
            }



        }




        [HttpPost]
        public ActionResult OnDone()
        {
            
            return RedirectToAction("Index", "Home");
        }

  



    }
}
