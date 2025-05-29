using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CodeJobs.Models; 
using CodeJobs.DataAccess.Data;
using System.Data.Entity;

namespace CodeJobs.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /User/MyProfile
        public async Task<ActionResult> MyProfile()
        {
            var userId = User.Identity.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return HttpNotFound();

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

            return View(model);
        }

        // GET: /User/UserAdd
        public async Task<ActionResult> UserAdd()
        {
            var userId = User.Identity.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return HttpNotFound();

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

            return View(model);
        }

        // POST: /User/UserAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserAdd(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userId = User.Identity.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return HttpNotFound();

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

            await _context.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        // GET: /User/Edit
        public async Task<ActionResult> Edit()
        {
            var userId = User.Identity.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return HttpNotFound();

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
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

            return View(model);
        }

        // POST: /User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null)
                return HttpNotFound();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Bio = model.Bio;
            user.JobTitle = model.JobTitle;
            user.Skills = model.Skills;
            user.ExperienceYears = model.ExperienceYears;
            user.EmploymentType = model.EmploymentType;
            user.PreferredLocation = model.PreferredLocation;
            user.LinkedInProfile = model.LinkedInProfile;

            await _context.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        // Check if the user profile is complete
        public async Task<ActionResult> FindJobRedirect()
        {
            var userId = User.Identity.GetUserId();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            // Profile validation logic
            bool isProfileComplete = !string.IsNullOrWhiteSpace(user?.FirstName)
                                     && !string.IsNullOrWhiteSpace(user.LastName)
                                     && !string.IsNullOrWhiteSpace(user.Email)
                                     && !string.IsNullOrWhiteSpace(user.PhoneNumber);

            if (!isProfileComplete)
            {
                // Profile completion
                return RedirectToAction("UserAdd", "User");
            }

            // JobList
            return RedirectToAction("JobsList", "Jobs");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}