using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Dotnet_Core_MVC.CustomActionFilters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string userId = _httpContextAccessor.HttpContext.User.Identity.Name;

            if (context.Controller is Controller controller1)
            {
                controller1.ViewBag.MyName = "Adi";
            }
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
          //  throw new NotImplementedException();
        }
    }
}
