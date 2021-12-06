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

        [HttpPost]

        public async Task<IActionResult> Subform(Dojo dojo)
        {

            JoinViewModel joinView = new JoinViewModel();



            UserDatabase userDatabase = new UserDatabase();
            var IsDataSent = await userDatabase.AddRequest(dojo);

            joinView.SetData(dojo);

           await AddRequest(dojo);



            JoinViewModel joinV = new JoinViewModel();

            return View("Index",joinV);
        }



      async Task AddRequest(Dojo _dojo)
        {
            UserDatabase userDatabase = new UserDatabase();
            var IsDataSent = await userDatabase.AddRequest(_dojo);

           

        }



    }
}
