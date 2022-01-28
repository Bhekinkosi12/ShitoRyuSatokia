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
            UserAuthService userAuth = new UserAuthService();
            if (userAuth.IsAuth())
            {
                return RedirectToAction("Index", "Edit");
            }
            else
            {

            return View();
            }

        }
        public IActionResult Signin()
        {
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }





        [HttpPost]
        public async Task<ActionResult> OnLogin(string email, string password)
        {
            UserAuthService userAuth = new UserAuthService();

            if(await userAuth.Login(email,password) != string.Empty)
            {
                return RedirectToAction("Index","Edit");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }


        }

        [HttpPost]
        public async Task<ActionResult> OnSignin(string code, string email, string password)
        {
            if(code == "satoK21")
            {

                UserAuthService userAuth = new UserAuthService();

                if(await userAuth.Signup(email,password) != string.Empty)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View("Signin");
                }
            }
            else
            {
                return View("Signin");
            }
        }


        [HttpPost]
        public async Task<ActionResult> OnReset(string email)
        {
            UserAuthService userAuth = new UserAuthService();

            if (email.Contains('@'))
            {

                if (await userAuth.ResetPass(email))
                {
                    return View("Index");

                }
                else
                {
                    return View("Reset");
                }


            }
            else
            {
                return View("Reset");
            }


        }



    }
}
