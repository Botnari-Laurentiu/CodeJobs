using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Domain.Interfaces;
using CodeJobs.Filters;
using CodeJobs.Models;

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

        public ActionResult EditUser(string id)
        {
            return HttpNotFound("Edit functionality is not implemented.");
        }

        public ActionResult DeleteUser(string id)
        {
            return HttpNotFound("Delete functionality is not implemented.");
        }
    }
}