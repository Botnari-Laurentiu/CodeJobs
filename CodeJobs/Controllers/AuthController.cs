using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Domain.Enums;
using CodeJobs.Models;

namespace CodeJobs.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Auth/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.Username,
                    Role = UserRole.User
                };

                var result = await _userService.RegisterUser(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View(model);
        }

        // GET: /Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    var role = user.Role.ToString();

                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        user.UserName,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        false,
                        role // UserData = role
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                    return RedirectToAction("HomeAuth", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            return View(model);
        }

        // POST: /Auth/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
