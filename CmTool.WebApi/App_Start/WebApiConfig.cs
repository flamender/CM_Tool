using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using CmTool.Api.App_Start;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;

namespace CmTool.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };


            // JSON only
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(json));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
