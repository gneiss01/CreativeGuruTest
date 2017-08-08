using System.Web.Mvc;
using TestWeb.Data.Model;
using TestWeb.Data.Repository;

namespace TestWeb.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> productRepo;

        public ProductController(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public ActionResult List()
        {
            return View();
        }
    }
}