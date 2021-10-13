using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Riodetask.AppCode.Middleware;
using Riodetask.AppCode.Provider;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Memberships;
using System;
using System.IO;

namespace Riode.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg=> {

                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
                
            });
            services.AddDbContext<RioDbContext>(cfg => {

                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });

            //ActionContextAccessor
            services.AddSingleton< IActionContextAccessor, ActionContextAccessor >();
            services.AddRouting(cfg => {

                cfg.LowercaseUrls = true;
            
            });
            //Membership


            services.AddIdentity<RiodeUser, RiodeRole>()
                .AddEntityFrameworkStores<RioDbContext>()
                .AddDefaultTokenProviders();


            services.AddScoped<UserManager<RiodeUser>>();
            services.AddScoped<SignInManager<RiodeUser>>();
            services.AddScoped<RoleManager<RiodeRole>>();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;


                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "";
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);
            });
            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.LoginPath = "/signin.html";
                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "riode";
            });
            services.AddAuthentication();
            services.AddAuthorization( cfg=>
            {
                foreach (var item in Program.principals)
                {
                    cfg.AddPolicy(item, p =>
                    {
                        p.RequireAssertion(h =>
                        {
                            return h.User.IsInRole("SuperAdmin") ||
                            h.User.HasClaim(item,"1");
                        });
                    });
                }
            });



            services.AddMediatR(this.GetType().Assembly);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("riode") &&
                context.Request.RouteValues.TryGetValue("area", out object areaName)
                && areaName.ToString().ToLower().Equals("admin"))
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    if (attr == null)
                    {
                        //context.Request.Path = "/admin/signin.html";
                        context.Response.Redirect("/admin/signin.html");
                        await context.Response.CompleteAsync();
                    }

                }
                    await next();
            });
            app.UseRequestLocalization(cfg =>
            {
                cfg.AddSupportedUICultures("az", "en");
                cfg.AddSupportedCultures("az", "en");
                cfg.RequestCultureProviders.Clear();
                cfg.RequestCultureProviders.Add(new CultureProvider());


            });
            app.UseStaticFiles();
            //app.SeedMembership();
            //middleware
            app.UseAudit();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {


                cfg.MapGet("/coming-soon.html", async (context) =>
                   {
                       using (var sr = new StreamReader("Views/static/coming-soon.html"))
                       {
                           context.Response.ContentType = "text/html";
                           await context.Response.WriteAsync(sr.ReadToEnd());

                       }
                   });
                //Culture provider MultiLanguage
                cfg.MapControllerRoute(
                 name: "areas-with-lang",
                 pattern: "{lang}/{area:exists}/{controller=Home}/{action=Index}/{id?}",
                 constraints : new
                 {
                     lang = "en|az|ru"
                 }
               );

                cfg.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                cfg.MapControllerRoute("default-with-lang", "{lang}/{controller=Home}/{action=index}/{id?}",constraints: new
                {
                    lang = "en|az|ru"
                });
                cfg.MapControllerRoute("admin", "admin/signin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "signin",
                        area = "Admin"
                    });
                cfg.MapControllerRoute("x", "signin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "signin",
                        area = ""
                    });
                cfg.MapControllerRoute("x", "register.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "register",
                        area = ""
                    });
                cfg.MapControllerRoute("logout.html", "admin/logout.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "logout",
                        area = "Admin"
                    });

                cfg.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

                
            });
        }
    }
}
