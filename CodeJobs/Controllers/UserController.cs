using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CodeJobs.Models;
using CodeJobs.Business_Logic.Core.Services;
using CodeJobs.Domain.Entities.User;

namespace CodeJobs.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService(new DataAccess.Data.ApplicationDbContext());
        }

        public async Task<ActionResult> MyProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
                return HttpNotFound();

            var model = MapToViewModel(user);
            return View(model);
        }

        public async Task<ActionResult> UserAdd()
        {
            var userId = User.Identity.GetUserId();
            var user = await _userService.GetUserById(userId);
            if (user == null)
                return HttpNotFound();

            var model = MapToViewModel(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserAdd(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.GetUserById(User.Identity.GetUserId());
            if (user == null)
                return HttpNotFound();

            UpdateUserFromViewModel(user, model);
            await _userService.UpdateUser(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        public async Task<ActionResult> Edit()
        {
            var user = await _userService.GetUserById(User.Identity.GetUserId());
            if (user == null)
                return HttpNotFound();

            var model = MapToViewModel(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.GetUserById(model.Id);
            if (user == null)
                return HttpNotFound();

            UpdateUserFromViewModel(user, model);
            await _userService.UpdateUser(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        public async Task<ActionResult> FindJobRedirect()
        {
            var user = await _userService.GetUserById(User.Identity.GetUserId());
            if (user == null)
                return RedirectToAction("Login", "Auth");

            bool isProfileComplete = !string.IsNullOrWhiteSpace(user.FirstName)
                                  && !string.IsNullOrWhiteSpace(user.LastName)
                                  && !string.IsNullOrWhiteSpace(user.Email)
                                  && !string.IsNullOrWhiteSpace(user.PhoneNumber);

            return isProfileComplete
                ? RedirectToAction("JobsList", "Jobs")
                : RedirectToAction("UserAdd", "User");
        }

        private UserViewModel MapToViewModel(ApplicationUser user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Bio = user.Bio,
                JobTitle = user.JobTitle,
                Skills = user.Skills,
                ExperienceYears = user.ExperienceYears,
                EmploymentType = user.EmploymentType,
                PreferredLocation = user.PreferredLocation,
                LinkedInProfile = user.LinkedInProfile
            };
        }

        private void UpdateUserFromViewModel(ApplicationUser user, UserViewModel model)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Bio = model.Bio;
            user.JobTitle = model.JobTitle;
            user.Skills = model.Skills;
            user.ExperienceYears = model.ExperienceYears;
            user.EmploymentType = model.EmploymentType;
            user.PreferredLocation = model.PreferredLocation;
            user.LinkedInProfile = model.LinkedInProfile;
        }
    }
}
