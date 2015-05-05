using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWorkshops.Infrastructure.ModelBinders
{
    public class IpModelBinder : DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor)
        {
            if ("UserIp".Equals(propertyDescriptor.Name))
            {
                propertyDescriptor.SetValue(bindingContext.Model, controllerContext.HttpContext.Request.UserHostAddress);
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
}