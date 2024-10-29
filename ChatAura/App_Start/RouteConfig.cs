using System.Web.Mvc;
using System.Web.Routing;

namespace ChatAura
{
    public static class RouteConfig // Добавлено "class"
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "ChatAura.Controllers" } // Убедитесь, что пространство имён соответствует вашему
            );
        }
    }
}
