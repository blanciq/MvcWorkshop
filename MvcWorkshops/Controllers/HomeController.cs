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
            Session["Number"] = Session["Number"] ?? Guid.NewGuid();
            var model = new IndexViewModel()
            {
                Messages = new List<string>
                {
                    "Hello world",
                    Session["Number"].ToString()
                }
            };
            return View(model);
        }
    }
}