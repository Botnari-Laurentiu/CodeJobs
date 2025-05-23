using System.Web.Mvc;
namespace CodeJobs.Filters
{
    public class AdminModAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Auth/Login");
                return;
            }

            if (!user.IsInRole("Admin"))
            {
                filterContext.Result = new HttpStatusCodeResult(403);
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}