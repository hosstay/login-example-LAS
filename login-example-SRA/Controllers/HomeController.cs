using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_example_SRA.Models;
using login_example_SRA.EFDataAccess;
using Newtonsoft.Json;

namespace login_example_SRA.Controllers
{
    public class HomeController : Controller
    {

        private UsersContext db = new UsersContext();

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

            var users = from u in db.Users select u;
            var data = users.ToList();

            List<UsersViewModel> usersViewList = new List<UsersViewModel>();

            foreach (var row in data)
            {
                usersViewList.Add(new UsersViewModel
                {
                    Id = row.ID,
                    Username = row.Username,
                    Password = row.Password,
                    Email = row.Email,
                    Age = row.Age
                });
            }

            return View(usersViewList);
        }

        public ActionResult CreateUsers()
        {
            ViewBag.Message = "User Sign Up.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users users = new Users
                {
                    Username = model.Username, 
                    Password = model.Password, 
                    Email = model.Email, 
                    Age = model.Age
                };

                db.Users.Add(users);
                db.SaveChanges();

                return RedirectToAction("ViewUsers");
            }

            return View();
        }

        public ActionResult UpdateUsers(int ID)
        {
            ViewBag.Message = "User Update.";

            var data = db.Users.Find(ID);

            UsersViewModel user = new UsersViewModel
            {
                Id = data.ID,
                Username = data.Username,
                Password = data.Password,
                Email = data.Email,
                Age = data.Age
            };

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUsers(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {

                var userToUpdate = db.Users.Find(model.Id);
                userToUpdate.Username = model.Username;
                userToUpdate.Password = model.Password;
                userToUpdate.Email = model.Email;
                userToUpdate.Age = model.Age;
                db.SaveChanges();

                return RedirectToAction("ViewUsers");               
            }

            return View();
        }

        public ActionResult DeleteUsers(int ID)
        {
            ViewBag.Message = "User Delete.";

            var userToDelete = db.Users.Find(ID);
            db.Users.Remove(userToDelete);
            db.SaveChanges();

            return RedirectToAction("ViewUsers");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
