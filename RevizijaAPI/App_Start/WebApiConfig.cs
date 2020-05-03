using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RevizijaAPI
{
    public static class WebApiConfig
    {
        public static string[] args { get; set; }
        private static string _config { get; set; }
        private static string _user { get; set; }
        private static string _pass { get; set; }
        public static Klase.Configuration Config { get; set; }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            string test = System.Web.Hosting.HostingEnvironment.MapPath("~/RevizijaApi.xml");
            Config = Klase.Configuration.Load(_config ?? System.Web.Hosting.HostingEnvironment.MapPath("~/RevizijaApi.xml"));

            // Web API routes
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "Login",
            //    routeTemplate: "api/operater/login/{username}/{password}"
            //);
        }
    }
}
