using Microsoft.AspNetCore.Mvc;

namespace ShitoRyuSatokia.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Auth()
        {
            ViewBag.Auth = "login";
            return View();
        }





        [HttpPost]
        public ActionResult ToSignin()
        {
            ViewBag.Auth = "signin";
            return View("Auth");
        }

    }
}
