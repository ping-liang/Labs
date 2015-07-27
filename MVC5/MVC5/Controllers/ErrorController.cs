using System.Web.Mvc;
using System.Web.UI;

namespace MVC5.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Http404()
        {
            Response.StatusCode = 404;

            Response.AddCacheDependency();
            return View();
        }
    }
}