using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI;

namespace MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
    }
}