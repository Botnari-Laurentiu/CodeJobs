using System;
using System.Web.Mvc;
using CodeJobs.Models; // Ensure you have a RegisterViewModel in the Models folder

namespace CodeJobs.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Register (Displays the registration page)
        public ActionResult Register()
        {
            return View();
        }

        // POST: Register (Handles form submission)
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add user registration logic here (e.g., saving user to database)

                // Redirect to login or home page after successful registration
                return RedirectToAction("Login");
            }

            // If the model is not valid, return the same view to show validation errors
            return View(model);
        }
    }
}
