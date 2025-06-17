using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Models;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Domain.Entities.User;
using System.Linq;

namespace CodeJobs.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var userName = User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
                return null;

            var users = await _userService.GetAllUsers();
            return users.FirstOrDefault(u => u.UserName == userName);
        }

        public async Task<ActionResult> MyProfile()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return Content("Not authenticated!");

            var model = MapToViewModel(user);
            return View(model);
        }

        public async Task<ActionResult> UserAdd()
        {
            var user = await GetCurrentUserAsync();
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

            var user = await GetCurrentUserAsync();
            if (user == null)
                return HttpNotFound();

            UpdateUserFromViewModel(user, model);
            await _userService.UpdateUser(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        public async Task<ActionResult> Edit()
        {
            var user = await GetCurrentUserAsync();
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

            var user = await GetCurrentUserAsync();
            if (user == null)
                return HttpNotFound();

            UpdateUserFromViewModel(user, model);
            await _userService.UpdateUser(user);
            await _userService.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        public async Task<ActionResult> FindJobRedirect()
        {
            var user = await GetCurrentUserAsync();
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
