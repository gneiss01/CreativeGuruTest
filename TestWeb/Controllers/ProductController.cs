using System.Linq;
using System.Web.Mvc;
using TestWeb.Data.Model;
using TestWeb.Data.Repository;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class ProductController : Controller
    {
        IProductRepo productRepo;
        IRepository<Category> categoryRepo;

        public ProductController(IProductRepo productRepo, IRepository<Category> categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()
        {
            return new CustomJsonResult() { Data = this.productRepo.GetAll() };
        }

        [HttpGet]
        public JsonResult Categories()
        {
            return new CustomJsonResult() { Data = this.categoryRepo.GetAll() };
        }
    }
}