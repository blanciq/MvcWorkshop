using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}