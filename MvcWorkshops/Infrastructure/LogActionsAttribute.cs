using System.Web.Mvc;
using Common.Logging;

namespace MvcWorkshops.Infrastructure
{
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