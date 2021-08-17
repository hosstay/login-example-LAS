using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using login_example_SRA.Models;

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
