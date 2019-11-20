using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vitec.Models;
using VitecData;
using VitecData.Models;
using VitecData.ServiceInterfaces;
using VitecServices;

namespace Vitec
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<VitecContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VitecContext")));

            _logger.LogInformation("Added VitecContext to services");

            services.AddIdentity<WebUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<VitecContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            /*services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _logger.LogInformation("In Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                _logger.LogInformation("In production environment AOEUOAHDOANEHUOTANUHEATONUAENOTUHEATONUOATNU");
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
