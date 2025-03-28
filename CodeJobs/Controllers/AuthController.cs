﻿using CodeJobs.Models;
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

                return RedirectToAction("HomeAuth", "Home");
            }

            // If model validation fails, return the view with validation errors
            return View(model);
        }
        // GET: /Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Authentication logic (e.g., check the user credentials)
                // If authentication is successful, redirect to the Home page or another page

                return RedirectToAction("HomeAuth", "Home");
            }

            // If model validation fails, return the view with validation errors
            return View(model);
        }
    }
}
