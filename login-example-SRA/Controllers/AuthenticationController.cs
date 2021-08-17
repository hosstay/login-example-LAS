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
using System.Web;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace login_example_SRA.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticationController(
            ApplicationDbContext db, 
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // loggging in with Identity package
                var foundUser = await _userManager.FindByNameAsync(model.Username);

                // Manual logging in like other test websites.
                // var foundUser = _db.LoginUsers
                //     .Where(user => user.Username == model.Username && user.Password == model.Password)
                //     .FirstOrDefault<LoginUsers>();

                if (foundUser != null) {

                    var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    } else {
                        ModelState.AddModelError("", "Could not sign in.");
                    }
                } else {
                    ModelState.AddModelError("", "Your username either doesn't exist or your password was wrong.");
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Register.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                // Registering with Identity package
                var user = new IdentityUser
                {
                    UserName = model.Username
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                } else {
                    ModelState.AddModelError("", "Could not sign in. That username has probably already been taken.");
                }

                // Manual Registering like other test websites.
                // var foundUser = _db.LoginUsers
                //     .Where(user => user.Username == model.Username)
                //     .FirstOrDefault<LoginUsers>();

                // if (foundUser == null) {

                //     LoginUsers users = new LoginUsers
                //     {
                //         Username = model.Username, 
                //         Password = model.Password
                //     };

                //     _db.LoginUsers.Add(users);
                //     _db.SaveChanges();
                    
                //     return RedirectToAction("Login");
                // } else {
                //     ModelState.AddModelError("", "That username has already been taken.");
                // }
            }

            return View();
        }

        public async Task<ActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
