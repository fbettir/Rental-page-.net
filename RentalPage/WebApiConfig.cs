using System.Web.Http;

namespace RentalPage.Api
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "default",
                routeTemplate: "rentItem",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}
