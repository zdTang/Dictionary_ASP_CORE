using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Models;
using Dictionary.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nancy.Json;

namespace Dictionary
{
    public class Startup
    {
        //private readonly ILogger _logger;
        public Startup(IConfiguration configuration/*, ILogger<Startup> logger*/)
        {
            Log.log("Startup starts...");
            Configuration = configuration;
            //_logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.log("ConfigureServices starts...");
            services.AddControllersWithViews();
            
            //services.AddTransient<DictionaryContext>();// Inject Generic DBcontext without specify connection string

            //Tang: Here to injection DbContext and specify Connection string as well.

            services.AddDbContext<DictionaryContext>(
                options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<AppUserRepository>();
            services.AddTransient<JavaScriptSerializer>();
            /*In order to use Session
             * need install Microsoft.AspNetCore.Session package 
             Clipped from: https://benjii.me/2016/07/using-sessions-and-httpcontext-in-aspnetcore   */
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.log("Configure starts...");
            if (env.IsDevelopment())
            {
                //_logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //_logger.LogInformation("In Production environment");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();   //  tell the ASP.NET core to user Memory Cache to store session

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
