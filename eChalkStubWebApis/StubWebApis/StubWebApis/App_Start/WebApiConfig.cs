using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StubWebApis
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //Class APIs
           // config.Routes.MapHttpRoute(
           //    name: "ClassApi",
           //    routeTemplate: "api/sites/{siteId}/classes/{id}",
           //    defaults: new { controller = "Classes", action = "SiteClasses", id = RouteParameter.Optional }
           //);
            config.Routes.MapHttpRoute(
               name: "ClassApi",
               routeTemplate: "api/sites/{siteId}/classes",
               defaults: new { controller = "Classes", action = "SiteClasses", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "ClassApi",
               routeTemplate: "api/sites/{siteId}/classes/{id}",
               defaults: new { controller = "Classes", action = "GetClass", id = RouteParameter.Optional }
           );

            //Student API
            config.Routes.MapHttpRoute(
               name: "StudentApi",
               routeTemplate: "api/sites/{id}/students",
               defaults: new { id = RouteParameter.Optional }
           );

            /*
            config.Routes.MapHttpRoute(
                name: "Search",
                routeTemplate: "api/{controller}/Search",
                defaults: new { id = RouteParameter.Optional }
            );
             * */
            
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
