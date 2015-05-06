using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Common.Logging;
using log4net.Repository.Hierarchy;
using MvcWorkshops.Extensions;
using MvcWorkshops.Infrastructure;
using MvcWorkshops.Infrastructure.ModelBinders;
using MvcWorkshops.Models.News;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Controllers
{
    [LogActions]
    [Authorize]
    public class NewsController : Controller
    {
        private readonly IRepository<News> _repository;

        public NewsController(IRepository<News> repository)
        {
            _repository = repository;
        }

        // GET: News
        public ActionResult Index()
        {
            ViewBag.MenuItem = "News";
            var model = new NewsIndexViewModel
            {
                News = _repository.GetAll().ToList()
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var news = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            if (news == null)
            {
                throw new Exception("Cannot find news with id " + id);
            }
            return Json(new
            {
                Success = true,
                PartialView = this.RenderPartialToString("_Details", news)
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(string news)
        {
            ViewBag.MenuItem = "News";
            return View(new NewsAddViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([ModelBinder(typeof(IpModelBinder))]NewsAddViewModel model)
        {
            LogManager.GetCurrentClassLogger().DebugFormat("Ip is: " + model.UserIp);

            _repository.Save(new News { Content = model.Message});

            this.AddSuccessMessage();

            return RedirectToAction("Index");
        }
    }
}