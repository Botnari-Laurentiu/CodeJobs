using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CodeJobs.Models; // UserViewModel
using CodeJobs.DataAccess.Data; // ApplicationDbContext
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
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
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

            user.FullName = model.FullName;

            await _context.SaveChangesAsync();

            return RedirectToAction("MyProfile");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();

            base.Dispose(disposing);
        }
    }
}
