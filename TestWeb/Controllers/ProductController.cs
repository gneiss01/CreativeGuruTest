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
        IRepository<Category> categoryRepo;

        public ProductController(IRepository<Product> productRepo, IRepository<Category> categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
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

        [HttpGet]
        public JsonResult Categories()
        {
            return new CustomJsonResult() { Data = this.categoryRepo.GetAll().ToList() };
        }
    }
}