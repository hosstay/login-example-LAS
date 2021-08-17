// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;

// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// using login_example_SRA.Models;
// using login_example_SRA.EFDataAccess;

// namespace login_example_SRA.Controllers
// {
//     public class HomeController : Controller
//     {
//         private readonly ILogger<HomeController> _logger;
//         private readonly ApplicationDbContext _db;

//         public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
//         {
//             _logger = logger;
//             _db = db;
//         }

//         public IActionResult Index()
//         {
//             return View();
//         }

//         public IActionResult Privacy()
//         {
//             return View();
//         }

//         public ActionResult ViewUsers()
//         {
//             ViewBag.Message = "User List";

//             var users = from u in _db.Users select u;
//             var data = users.ToList();

//             List<UsersViewModel> usersViewList = new List<UsersViewModel>();

//             foreach (var row in data)
//             {
//                 usersViewList.Add(new UsersViewModel
//                 {
//                     Id = row.ID,
//                     Username = row.Username,
//                     Password = row.Password
//                 });
//             }

//             return View(usersViewList);
//         }

//         public ActionResult CreateUsers()
//         {
//             ViewBag.Message = "User Sign Up.";

//             return View();
//         }

//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult CreateUsers(UsersViewModel model)
//         {
//             if (ModelState.IsValid)
//             {
//                 Users users = new Users
//                 {
//                     Username = model.Username, 
//                     Password = model.Password
//                 };

//                 _db.Users.Add(users);
//                 _db.SaveChanges();

//                 return RedirectToAction("ViewUsers");
//             }

//             return View();
//         }

//         public ActionResult UpdateUsers(int ID)
//         {
//             ViewBag.Message = "User Update.";

//             var data = _db.Users.Find(ID);

//             UsersViewModel user = new UsersViewModel
//             {
//                 Id = data.ID,
//                 Username = data.Username,
//                 Password = data.Password
//             };

//             return View(user);
//         }

//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public ActionResult UpdateUsers(UsersViewModel model)
//         {
//             if (ModelState.IsValid)
//             {

//                 var userToUpdate = _db.Users.Find(model.Id);
//                 userToUpdate.Username = model.Username;
//                 userToUpdate.Password = model.Password;
//                 _db.SaveChanges();

//                 return RedirectToAction("ViewUsers");               
//             }

//             return View();
//         }

//         public ActionResult DeleteUsers(int ID)
//         {
//             ViewBag.Message = "User Delete.";

//             var userToDelete = _db.Users.Find(ID);
//             _db.Users.Remove(userToDelete);
//             _db.SaveChanges();

//             return RedirectToAction("ViewUsers");
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//         }
//     }
// }
