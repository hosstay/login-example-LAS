using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using login_example_SRA.Models;

namespace login_example_SRA.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListUsers()
        {
            List<UserModel> users = new List<UserModel>();

            users.Add(new UserModel { Username = "TimTimmerson", Email = "tim@tim.com", Password = "TimTimmerson", Age = 38, IsRobot = false });
            users.Add(new UserModel { Username = "JoeJoemandoe", Email = "joe@joe.com", Password = "JoeJoemandoe", Age = 56, IsRobot = true });
            users.Add(new UserModel { Username = "SarahBobeara", Email = "sarah@sarah.com", Password = "SarahBobeara", Age = 25 });

            return View(users);
        }
        
        public ActionResult CreateUsers()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsers(UserModel model)
        {
            if (ModelState.IsValid)
            {
                using(SqlConnection con = new SqlConnection(StoreConnection.getConnection()))
                {
                    using(SqlCommand cmd = new SqlCommand("INSERT INTO users(username, email, password, age, is_robot) VALUES ('"+ model.Username +"', '"+ model.Email +"', '"+ model.Password+"', '"+ model.Age +"', '"+ model.IsRobot +"',)", con))
                    {
                        if (con.State != System.Data.ConnectionState.Open)
                            con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("ListUsers");
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