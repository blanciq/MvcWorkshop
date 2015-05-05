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
                News = _repository.GetAll().Select(x => x.Content).ToList()
            };
            return View(model);
        }

        public ActionResult Add(string news)
        {
            ViewBag.MenuItem = "News";
            return View(new NewsAddViewModel());
        }

        public ActionResult Exception()
        {
            throw new WebException("Oooops!");
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

    public class LogActionsAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = LogManager.GetLogger("LogActions");
            logger.TraceFormat("Calling {0}.{1}", 
                filterContext.RouteData.Values["controller"],
                filterContext.RouteData.Values["action"]);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                var logger = LogManager.GetLogger("LogActions");
                logger.Trace("Exception occured", filterContext.Exception);
            }
        }
    }
}