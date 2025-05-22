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
            return View();
        }

        //ABOUT CONTACT
        public ActionResult Contact()
        {
            return View();
        }

        //ABOUT TERMS
        public ActionResult Terms()
        {
            return View();
        }

        //ABOUT HELP
        public ActionResult Help()
        {
            return View();
        }

        //ABOUT PRIVACY
        public ActionResult Privacy()
        {
            return View();
        }


    }
}
