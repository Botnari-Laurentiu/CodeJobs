using CodeJobs.Models;
using System.Linq;
using System.Web.Mvc;
using ApplicationDbContext = CodeJobs.Models.ApplicationDbContext;

namespace CodeJobs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Home No Auth
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult HomeAuth()
        {
            var jobPosts = _context.JobPosts.ToList();
            return View(jobPosts);
        }

        //ABOUT PAGE
        public ActionResult About()
        {
            return View("~/Views/StaticPages/About.cshtml");
        }

        //ABOUT CONTACT
        public ActionResult Contact()
        {
            return View("~/Views/StaticPages/Contact.cshtml");
        }

        //ABOUT TERMS
        public ActionResult Terms()
        {
            return View("~/Views/StaticPages/Terms.cshtml");
        }

        //ABOUT HELP
        public ActionResult Help()
        {
            return View("~/Views/StaticPages/Help.cshtml");
        }

        //ABOUT PRIVACY
        public ActionResult Privacy()
        {
            return View("~/Views/StaticPages/Privacy.cshtml");
        }


    }
}
