using CodeJobs.Models;
using System.Web.Mvc;
using CodeJobs.Models; // Import the RegisterViewModel namespace

namespace YourNamespace.Controllers
{
    public class AuthController : Controller
    {
        // GET: /Auth/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Registration logic (e.g., save the user to the database)
                // If registration is successful, redirect to the Home page or another page

                return RedirectToAction("Index", "Home");
            }

            // If model validation fails, return the view with validation errors
            return View(model);
        }
    }
}