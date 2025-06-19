using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Filters;
using CodeJobs.Models;
using CodeJobs.Domain.Enums;

namespace CodeJobs.Controllers
{
    [AdminMod]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public async Task<ActionResult> ManageUsers()
        {
            var users = await _userService.GetAllUsers();

            var model = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString()
            }).ToList();

            return View(model);
        }

        // GET: /Admin/EditUser/{id}
        public async Task<ActionResult> EditUser(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return HttpNotFound();

            var model = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
            return View(model);
        }

        // POST: /Admin/EditUser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.GetUserById(model.Id);
            if (user == null)
                return HttpNotFound();

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.Role = (UserRole)Enum.Parse(typeof(UserRole), model.Role, true);

            await _userService.UpdateUser(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("ManageUsers");
        }

        // POST: /Admin/DeleteUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return HttpNotFound();

            await _userService.DeleteUserAsync(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("ManageUsers");
        }
    }
}
