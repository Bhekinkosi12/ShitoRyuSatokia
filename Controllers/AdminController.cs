using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShitoRyuSatokia.Models;
using ShitoRyuSatokia.Services;


namespace ShitoRyuSatokia.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }





        [HttpPost]
        public async Task<IActionResult> OnLogin(string email, string password)
        {
            UserAuthService userAuth = new UserAuthService();

            if(await userAuth.Login(email,password) != string.Empty)
            {
                return RedirectToAction("Index","Edit");;
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }


        }

        [HttpPost]
        public async Task<IActionResult> OnSignin(string email, string password)
        {

            UserAuthService userAuth = new UserAuthService();

            if(await userAuth.Signup(email,password) != string.Empty)
            {
                return RedirectToAction("Index", "Edit");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }



    }
}
