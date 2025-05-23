using System.Linq;
using System.Web.Mvc;
using CodeJobs.Domain.Entities.User;
using CodeJobs.Filters;
using CodeJobs.Models;
using CodeJobs.DataAccess; // Assuming ApplicationDbContext is here

namespace CodeJobs.Controllers
{
    [AdminMod]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            var users = db.Users.ToList();

            var model = users.Select(u => new UserViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString()
            }).ToList();

            return View(model);
        }

        public ActionResult EditUser(string id)
        {
            return HttpNotFound("Edit functionality is not implemented.");
        }

        public ActionResult DeleteUser(string id)
        {
            return HttpNotFound("Delete functionality is not implemented.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}