using CodeJobs.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;
using CodeJobs.DataAccess;

namespace YourNamespace.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController()
        {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            _userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: /Auth/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.Username, 
                    Role = UserRole.JobSeeker  
                };

                try
                {
                    var result = _userManager.Create(user, model.Password);

                    if (result.Succeeded)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, false); // Autentificare utilizator
                        return RedirectToAction("HomeAuth", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            ModelState.AddModelError("", $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
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
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Find(model.Email, model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false); // Creează cookie-ul de autentificare
                    return RedirectToAction("HomeAuth", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            return View(model);
        }

        // GET: /Auth/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Auth");
        }
    }
}
