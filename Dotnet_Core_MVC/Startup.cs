using Dotnet_Core_MVC.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Core_MVC.CustomActionFilters;
using Microsoft.Extensions.FileProviders;
using Microsoft.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Web.Http;

namespace Dotnet_Core_MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:3000/")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Policy1", builder =>
            //    {
            //        builder.WithOrigins("http://localhost:3000")
            //        .WithMethods("POST", "GET", "PUT", "DELETE")
            //        .WithHeaders(HeaderNames.ContentType);
            //    });
            //});

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            var ConnectionString = Configuration.GetConnectionString("SQLDB");
            //Entity Framework  
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ConnectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

           // app.UseCors();

            

            // app.UseCors("Policy1");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // don't delete : exp for ASP.NET Core disable authentication in development environment
            //app.UseEndpoints(endpoints =>
            //{
            //    if (env.IsDevelopment())
            //        endpoints.MapControllers().WithMetadata(
            //            new AllowAnonymousAttribute());
            //    else
            //        endpoints.MapControllers();
            //});
            // don't delete : exp for ASP.NET Core disable authentication in development environment

            app.UseAuthorization();



            //    app.UseStaticFiles(new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider
            //      (Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/UploadedFiles")),
            //        RequestPath = new PathString("/wwwroot/UploadedFiles")
            //    });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }




        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();

        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("Policy1", builder =>
        //        {
        //            builder.WithOrigins("http://localhost:3000")
        //            .WithMethods("POST", "GET", "PUT", "DELETE")
        //            .WithHeaders(HeaderNames.ContentType);
        //        });
        //    });

        //    // The cors policy definition
        //    //services.AddCors(options =>
        //    //{
        //    //    options.AddPolicy("cors", policy =>
        //    //    {
        //    //        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //    //    });
        //    //});
        //    // ends here




        //    //Enable CORS
        //    //services.AddCors(c =>
        //    //{
        //    //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        //    //});


        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(new CustomActionFilter());
        //    });


        //    services.AddControllersWithViews();
        //    services.AddHttpContextAccessor();
        //    var ConnectionString = Configuration.GetConnectionString("SQLDB");
        //    //Entity Framework  
        //    services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ConnectionString));
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //    //Enable CORS
        //    // app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }

        //    //app.UseCors("cors");
        //    app.UseCors("Policy1");

        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthorization();


        //    app.UseStaticFiles(new StaticFileOptions()
        //    {
        //        FileProvider = new PhysicalFileProvider
        //      (Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/UploadedFiles")),
        //        RequestPath = new PathString("/wwwroot/UploadedFiles")
        //    });


        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
    }
}
