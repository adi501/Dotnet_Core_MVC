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
