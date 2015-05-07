using System;
using System.Linq;
using System.Web.Mvc;
using MvcWorkshops.Models;
using MvcWorkshops.Models.ShoppingCart;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ShoppingCartController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            var model = new ShoppingCartIndexViewModel();

            var cart = Session["cart"] as ShoppingCartModel ?? new ShoppingCartModel();

            model.Products = cart.Products;

            return View(model);
        }

        public ActionResult Header()
        {
            var cart = Session["cart"] as ShoppingCartModel;
            var model = new ShoppingCartHeaderViewModel();
            if (cart != null)
            {
                model.Count = cart.Products.Count;
                model.Total = cart.Products.Sum(x => x.Price);
            }
            return PartialView("_Header", model);
        }

        [HttpPost]
        public ActionResult AddToShoppingCart(long id)
        {
            var product = _productRepository.GetAll().SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new ArgumentException("No such product");
            }
            var model = Session["cart"] as ShoppingCartModel ?? new ShoppingCartModel();

            model.Products.Add(product);

            Session["cart"] = model;
            return Content("<h1>Product added to shopping cart</h1><p>Product has been successfully added to you shopping cart. What would you like to do next?");
        }
    }
}