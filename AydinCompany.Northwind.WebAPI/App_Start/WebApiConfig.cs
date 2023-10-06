using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AydinCompany.Northwind.WebAPI.MessageHandlers;

namespace AydinCompany.Northwind.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new AuthenticationHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
