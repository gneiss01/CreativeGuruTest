using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    }
}