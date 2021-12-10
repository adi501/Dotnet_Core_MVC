using Dotnet_Core_MVC.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dotnet_Core_MVC.Controllers
{
    public class Call_A_SQL_FunctionController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public Call_A_SQL_FunctionController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
          ViewBag.functionOutput= _databaseContext.funFullName.FromSqlInterpolated($"select dbo.funFullName('adi','jc') as FullName").FirstOrDefault().FullName;
            return View();
        }
    }
}
