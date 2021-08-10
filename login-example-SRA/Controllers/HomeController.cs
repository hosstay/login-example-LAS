using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_example_SRA.Models;
using static DataLibrary.BusinessLogic.UserProcessor;
using Newtonsoft.Json;

namespace login_example_SRA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult ViewUsers()
        {
            ViewBag.Message = "User List";

            var data = LoadUsers();
            List<UserViewModel> users = new List<UserViewModel>();

            foreach (var row in data)
            {
                users.Add(new UserViewModel
                {
                    Id = row.Id,
                    Username = row.Username,
                    Password = row.Password,
                    Email = row.Email,
                    Age = row.Age
                });
            }

            return View(users);
        }

        public ActionResult CreateUsers()
        {
            ViewBag.Message = "User Sign Up.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateUser(
                    model.Username,
                    model.Password,
                    model.Email,
                    model.Age
                );

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult UpdateUsers(int Id)
        {
            ViewBag.Message = "User Update.";

            var data = LoadUser(Id);

            UserViewModel user = new UserViewModel
            {
                Id = data.Id,
                Username = data.Username,
                Password = data.Password,
                Email = data.Email,
                Age = data.Age
            };

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUsers(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = UpdateUser(
                    model.Id,
                    model.Username,
                    model.Password,
                    model.Email,
                    model.Age
                );

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult DeleteUsers(int Id)
        {
            ViewBag.Message = "User Delete.";

            var data = LoadUser(Id);

            UserViewModel user = new UserViewModel
            {
                Id = data.Id
            };

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsers(UserViewModel model)
        {
            if (model.Id != null)
            {
                int recordsCreated = DeleteUser(
                    model.Id
                );

                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
