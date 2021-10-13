using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Riodetask.Model.DataContexts;
using Riodetask.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Riodetask.AppCode.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuditMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var routeData = httpContext.GetRouteData();
            var log = new AuditLog();
            using (var scope = httpContext.RequestServices.CreateScope())
            {
                RioDbContext db =  scope.ServiceProvider.GetRequiredService<RioDbContext>();
                log.CreatedTime = DateTime.Now;
                log.RequestTime = DateTime.Now;
                log.IsHttps = httpContext.Request.IsHttps;
                log.Method = httpContext.Request.Method;
                log.Path = httpContext.Request.Path;
                if (routeData.Values.TryGetValue("area", out object area))
                {
                    log.Area = area.ToString();
                }
                if (routeData.Values.TryGetValue("controller", out object cont))
                {
                    log.Controller = cont.ToString();
                }
                if (routeData.Values.TryGetValue("action", out object action))
                {
                    log.Action = action.ToString();
                }
                if (!string.IsNullOrWhiteSpace(httpContext.Request.QueryString.Value))
                {
                    log.QueryString = httpContext.Request.QueryString.Value;
                }

                await _next(httpContext);
                log.StatusCode = httpContext.Response.StatusCode;
                log.ResponseTime = DateTime.Now;
                db.AuditLogs.Add(log);
                db.SaveChanges();
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuditMiddlewareExtensions
    {
        public static IApplicationBuilder UseAudit(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuditMiddleware>();
        }
    }
}
