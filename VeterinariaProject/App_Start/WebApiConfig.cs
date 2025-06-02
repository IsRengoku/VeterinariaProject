using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using VeterinariaProject.Authenticate;

namespace VeterinariaProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Habilitar CORS globalmente
            var cors = new EnableCorsAttribute("*", "*", "*"); // origenes, headers, métodos
            config.EnableCors(cors);

            // Fix circular reference issue in JSON
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API configuration and services
            config.MessageHandlers.Add(new TokenValidationHandler());

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
