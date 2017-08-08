using System.Linq;
using System.Web.Mvc;
using TestWeb.Data.Model;
using TestWeb.Data.Repository;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> productRepo;

        public ProductController(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            return new CustomJsonResult() { Data = this.productRepo.GetAll().ToList() };
        }
    }
}