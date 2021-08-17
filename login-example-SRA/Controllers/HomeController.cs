using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_example_SRA.Models;
using Newtonsoft.Json;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace login_example_SRA.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            // Console.WriteLine(Request.Cookies["SessionToken"]);

            return View();
        }

        [Authorize]
        public IActionResult NamePage()
        {
            return View();
        }

        [Authorize]
        public IActionResult Surf()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Logout", "Authentication");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
