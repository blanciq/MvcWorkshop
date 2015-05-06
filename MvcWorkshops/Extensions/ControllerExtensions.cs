using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcWorkshops.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddSuccessMessage(this Controller ctrl)
        {
            AddMessage(ctrl, "Save successfull");
        }

        public static void AddMessage(this Controller ctrl, string message)
        {
            ctrl.TempData["Message"] = message;
        }

        public static string RenderPartialToString(this Controller ctrl, string viewName, object modelData)
        {
            var result = new PartialViewResult()
            {
                View = ViewEngines.Engines.FindPartialView(ctrl.ControllerContext, viewName).View,
                TempData = ctrl.TempData,
                ViewData = new ViewDataDictionary(modelData)
            };
            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                result.View.Render(new ViewContext(ctrl.ControllerContext, result.View, result.ViewData, result.TempData, writer), writer);    
            }
            return sb.ToString();
        }

    }
}