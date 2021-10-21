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

            JoinViewModel joinViewModel = new JoinViewModel();
            return View(joinViewModel);
        }

        [HttpPost]

        public  IActionResult Subform(string Dname,string DIname,string Demail,string DIposition,string Dlocation,string DIinfo,string Dinfo,string Drule,string Dtime)
        {

            JoinViewModel joinView = new JoinViewModel();
            


            Dojo dojo = new Dojo()
            {
                 Dojo_Name = Dname,
                  Dojo_Instructor = DIname,
                   Dojo_Instructor_Email = Demail,
                    Dojo_Instructor_Position = DIposition,
                      location = Dlocation,
                       Dojo_Instructor_Description = DIinfo,
                         Dojo_Description = Dinfo,
                          Dojo_Time = Dtime,
                           Regulation = Drule
            };
            joinView.SetData(dojo);

            AddRequest(dojo);



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
