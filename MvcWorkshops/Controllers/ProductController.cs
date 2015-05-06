using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repository;

        public const int PAGE_SIZE = 8;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: Product

        public ActionResult Index(int page = 1, int pageSize = PAGE_SIZE)
        {
            var allProds = _repository.GetAll().ToList();
            var max = (allProds.Count()/pageSize) + 1;
            
            var model = new ProductIndexViewModel
            {
                Products = allProds.Skip((page - 1) * pageSize).Take(pageSize)
            };
            model.Paging = new PagingModel
            {
                Curr = page,
                Max = max
            };
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ActionMethod()
        {
            // get from db
            return Content("Footer");
        }
    }

    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingModel Paging { get; set; }
    }

    public class PagingModel
    {
        public int Curr { get; set; }
        public int Max { get; set; }
    }
}