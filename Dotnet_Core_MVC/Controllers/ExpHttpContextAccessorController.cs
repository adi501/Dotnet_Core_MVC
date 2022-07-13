using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Core_MVC.Controllers
{
    public class ExpHttpContextAccessorController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public IActionResult Index()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            ViewBag.userName = userName;
            return View();
        }
    }
}
