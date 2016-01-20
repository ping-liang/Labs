using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DummyQueueApis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("GetUsers", "queue/slate/migrate/user/files/message",
            new
            {
                controller = "Message",
                action = "GetUsers"
            });

            config.Routes.MapHttpRoute("PostResponse", "queue/slate/migrate/user/files",
                new
                {
                    controller = "Message",
                    action = "PostResponse"
                });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
