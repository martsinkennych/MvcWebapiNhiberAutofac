using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcWebapiNhiberAutofac
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var xmlFormatter = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(
                t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xmlFormatter);
            config.Formatters.Remove(config.Formatters.XmlFormatter); // удаляем xml-форматтер

            var jsonFormatter = config.Formatters.JsonFormatter; // создаём json-форматтер
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        }
    }
}
