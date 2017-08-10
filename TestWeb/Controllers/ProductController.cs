using System;
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

        [HttpPost]
        public JsonResult Create(Product product)
        {
            product.Id = Guid.NewGuid();
            this.productRepo.Add(product);
            this.productRepo.Save();

            return new CustomJsonResult()
            {
                Data = product
            };
        }

        [HttpPost]
        public JsonResult Update(Product product)
        {
            this.productRepo.Update(product);
            this.productRepo.Save();

            return new JsonResult()
            {
                Data = product
            };
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var product = this.productRepo.FindByKey(id);
                if (product == null)
                {
                    Response.StatusCode = 404;
                    return Json($"Product with Id:'{id}' does not exist.");
                }

                this.productRepo.Delete(product);
                this.productRepo.Save();

                return Json(id);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 505;
                return Json(ex.Message);
            }
        }
    }
}