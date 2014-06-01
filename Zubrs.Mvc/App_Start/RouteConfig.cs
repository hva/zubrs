using System.Web.Mvc;
using System.Web.Routing;
using Zubrs.Mvc.Infrastrucrure;

namespace Zubrs.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                RouteName.News,
                "news"
            );

            routes.MapRoute(
                RouteName.Teams,
                "teams"
            );

            routes.MapRoute(
                RouteName.Competitions,
                "competitions"
            );

            routes.MapRoute(
                RouteName.Competition,
                "competitions/{id}"
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
