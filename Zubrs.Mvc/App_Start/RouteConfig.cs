using System.Web.Mvc;
using System.Web.Routing;
using Zubrs.Mvc.Infrastructure;

namespace Zubrs.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                RouteName.News,
                "news",
                new { controller = "news", action = "list" }
            );

            routes.MapRoute(
                RouteName.NewsItem,
                "news/{id}",
                new { controller = "news", action = "detail" }
            );

            routes.MapRoute(
                RouteName.Teams,
                "teams",
                new { controller = "teams", action = "index" }
            );

            routes.MapRoute(
                RouteName.Team,
                "teams/{id}"
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
                RouteName.Season,
                "season/{id}"
            );

            routes.MapRoute(
                RouteName.Management,
                "management"
            );

            routes.MapRoute(
                RouteName.History,
                "history"
            );

            routes.MapRoute(
                RouteName.Photo,
                "photo"
            );

            routes.MapRoute(
                RouteName.Video,
                "video"
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
