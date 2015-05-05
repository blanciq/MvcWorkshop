using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWorkshops.Models.Home;

namespace MvcWorkshops.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MenuItem = "Homepage";
            var model = new IndexViewModel()
            {
                Messages = new List<string>
                {
                    "Hello world",
                    "My first MVC app"
                }
            };
            return View(model);
        }
    }
}