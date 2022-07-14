using ApiExaustor.SimulatedThings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiExaustor
{
    public static class WebApiConfig
    {
        public static ExhaustFan exhaustFan;

        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web
            exhaustFan = ExhaustFan.Instance;


            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
