using IntexMummy11.Data;
using IntexMummy11.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PostgresCRUD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;


namespace IntexMummy11
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBurialRepository, EFBurialRepository>();

            var sqlConnectionString = Configuration["ConnectionString"];
            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddDbContext<ebdbContext>(options => options.UseNpgsql(sqlConnectionString));
            
            //services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<ebdbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                //Password requirements
                options.Password.RequiredLength = 15;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                //other requirements
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<PostgreSqlContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Redirect HTTP traffic HTTPS
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseStaticFiles();


            //Content Security Policy Header
            app.Use(async (ctx, next) =>
            {
                string cspValue =
                    "default-src 'self';" +
                    "style-src 'self' 'sha256-aqNNdDLnnrDOnTNdkJpYlAxKVJtLt9CtFLklmInuUAE=';" +
                    "img-src 'self' data:;" +
                    "script-src 'self' 'sha256-m1igTNlg9PL5o60ru2HIIK6OPQet2z9UgiEAhCyg/RU='";

                ctx.Response.Headers.TryAdd("Content-Security-Policy", cspValue);
                await next();
            });



            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
