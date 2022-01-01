using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models;
using ShitoRyuSatokia.Services;
using ShitoRyuSatokia.Models.MicroModel;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace ShitoRyuSatokia.Controllers
{
    public class EditController : Controller
    {

        public static string Newss;
        
        public async Task<ActionResult> Index()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            UserDatabase userDatabase = new UserDatabase();
            UserAuthService userAuth = new UserAuthService();
           var item = await userDatabase.GetAllDojos();
            var items = await userDatabase.GetAllNews();
            var iteme = await userDatabase.GetDojoRequest();

            ViewBag.Modelas = iteme;
            ViewBag.Models = item;
            ViewBag.Modeles = items;


            if (userAuth.IsAuth())
            {

            return View();
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }

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

        public IActionResult Requestview(string Newsid)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditDojo(string DojoName)
        {
            UserDatabase userDatabase = new UserDatabase();
            Dojo _dojo = new Dojo();
            var list = await userDatabase.GetAllDojos();

            foreach(var i in list)
            {
                if(i.ID == DojoName)
                {
                    _dojo = i;
                }
            }


            AdminViewModel adminView = new AdminViewModel(DojoName);

            var item = adminView.ReturnDojo();

            _dojo.IsNew = "false";


            return View("Dojoview",_dojo);
        }


        [HttpPost]
        public async Task<ActionResult> OpenRequest(string DojoName)
        {
            UserDatabase userDatabase = new UserDatabase();
            Dojo _dojo = new Dojo();
            var list = await userDatabase.GetDojoRequest();

            foreach (var i in list)
            {
                if (i.ID == DojoName)
                {
                    _dojo = i;
                }
            }


            AdminViewModel adminView = new AdminViewModel(DojoName);

            var item = adminView.ReturnDojo();

            _dojo.IsNew = "false";


            return View("Requestview", _dojo);
        }


        [HttpPost]
        public async Task<ActionResult> AddDojo(Dojo dojo)
        {
            UserDatabase userDatabase = new UserDatabase();

            await userDatabase.AddDojoAsync(dojo);
            

            return View("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteDojo(string id)
        {
            UserDatabase userDatabase = new UserDatabase();

            Dojo dojo = new Dojo()
            {
                ID = id
            };

            await userDatabase.DeleteDojo(dojo);

            return View("Index");
        }


        [HttpPost]
        public async Task<ActionResult> EditRequest(string DojoName)
        {
            UserDatabase userDatabase = new UserDatabase();
            Dojo _dojo = new Dojo();
            var list = await userDatabase.GetAllDojos();

            foreach (var i in list)
            {
                if (i.ID == DojoName)
                {
                    _dojo = i;
                }
            }


            AdminViewModel adminView = new AdminViewModel(DojoName);

            var item = adminView.ReturnDojo();

            _dojo.IsNew = "false";


            return View("Dojoview", _dojo);
        }



        [HttpPost]
        public async Task<ActionResult> EditNews(string Newsid)
        {
            News news = new News();
            Newss = Newsid;
            AdminViewModel adminView = new AdminViewModel(Newsid, true);
            UserDatabase userDatabase = new UserDatabase();
            var dj = await userDatabase.GetAllNews();

           foreach(var i in dj)
            {
                if(i.Id == Newsid)
                {
                    news = i;
                }
            }

            var item = adminView.ReturnNews();

            news.IsNew = "false";

            return View("Newsview", news);
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
        public async Task<ActionResult> UpdateDojo(Dojo dojo,IFormFile file)
        {
            PostViewModel postViewModel = new PostViewModel();
            UserStorage userStorage = new UserStorage();
            UserDatabase userDatabase = new UserDatabase();


        
            string link;



            if(file != null)
            {

               var stream =  file.OpenReadStream();
    

                    link = await userStorage.AddStoreStream(Guid.NewGuid().ToString(), stream);
            

                

                Dojo _dojo = new Dojo()
                {
                    Dojo_Description = dojo.Dojo_Description,
                    Dojo_Instructor_Description = dojo.Dojo_Instructor_Description,
                    Dojo_Instructor = dojo.Dojo_Instructor,
                    Dojo_Instructor_Email = dojo.Dojo_Instructor_Email,
                    Dojo_Instructor_Image = link,
                    Dojo_Instructor_Number = dojo.Dojo_Instructor_Number,
                    Dojo_Instructor_Position = dojo.Dojo_Instructor_Position,
                    Dojo_Instructor_Surname = dojo.Dojo_Instructor_Surname,
                    Dojo_Name = dojo.Dojo_Name,
                    Dojo_Schedule = dojo.Dojo_Schedule,
                    Dojo_Time = dojo.Dojo_Time,
                    ID = dojo.ID,
                    location = dojo.location,
                    Regulation = dojo.Regulation
                };






                if (dojo.IsNew == "true")
                {
                    await userDatabase.AddDojoAsync(dojo);
                }
                else
                {
                    await userDatabase.UpdateDojo(dojo);

                    /// postViewModel.UpdateDojo(dojo);
                }


            }
            else
            {


                if (dojo.IsNew == "true")
                {
                    //postViewModel.AddDojo(dojo);
                    await userDatabase.AddDojoAsync(dojo);
                }
                else
                {
                    // postViewModel.AddDojo(dojo);
                    await userDatabase.UpdateDojo(dojo);
                    /// postViewModel.UpdateDojo(dojo);
                }
            }


           


            return RedirectToAction("Index", "Edit");

        }

        [HttpPost]
        public async Task<ActionResult> UpdateNews(News news,IFormFile file)
        {
            PostViewModel postViewModel = new PostViewModel();
            UserStorage userStorage = new UserStorage();
            UserDatabase userDatabase = new UserDatabase();

            News _news = new News();
            _news = news;

            string link;

            if (file != null)
            {

                var stream = file.OpenReadStream();


                link = await userStorage.AddStoreStream(Guid.NewGuid().ToString(), stream);


                _news.Cover_Image = link;

               




            }



            if (news.IsNew == "true")
            {
              //  postViewModel.AddNews(_news);
               await userDatabase.AddNews(_news);
            }
            else
            {
                //  postViewModel.AddNews(_news);
                // postViewModel.UpDateNews(news);

                await userDatabase.UpdateNews(_news);

            }


            return RedirectToAction("Index","Edit");

        }

    }
}
