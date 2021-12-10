Step 1: Create .net core MVC project with Entity framework

Step 2:  Create Function in SQL Server

create function funFullName(@firstName varchar(10),@lastName varchar(10))
RETURNS varchar(25)
AS
BEGIN
	RETURN @firstName+' '+@lastName
END

Step 3:  Add Connection in "appsettings.json" file 

 "ConnectionStrings": {
    "SQLDB": "Server=.;Database=Dotnet_Core_MVC;Trusted_Connection=True;"
  },

Step 4:  Create Model class in "FuntionOutput.cs" under DBContext/Models folder

namespace Dotnet_Core_MVC.DBContext.Models
{
    public class FuntionOutput
    {
        public string FullName { get; set; }
    }
}

Step 5:  Create class in "DatabaseContext.cs" under DBContext folder

using Dotnet_Core_MVC.DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Core_MVC.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        //Funtion Call
        public virtual DbSet<FuntionOutput> funFullName { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuntionOutput>(e => e.HasNoKey());
        }
    }
}

Step 6:  Create Controller "Call_A_SQL_FunctionController.cs"  and call the SQL Function ass below code.

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


Step 7:  Create View and add below code.

<h5>Function Output:</h5>@ViewBag.functionOutput

Step 8:  Open "Startup.cs" class and update "ConfigureServices" method as below.

 public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var ConnectionString = Configuration.GetConnectionString("SQLDB");
            //Entity Framework  
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ConnectionString));
        }

Github Code: https://github.com/adi501/Dotnet_Core_MVC
