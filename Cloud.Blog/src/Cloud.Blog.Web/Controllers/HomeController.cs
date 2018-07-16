using Microsoft.AspNetCore.Mvc;

namespace Cloud.Blog.Web.Controllers
{
    public class HomeController : BlogControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}