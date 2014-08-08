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
                RouteName.NewsPage,
                "news/page/{page}",
                new { controller = "news", action = "list", page = 0 }
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
                "teams/{id}",
                new { controller = "teams", action = "index" }
            );

            routes.MapRoute(
                RouteName.Competitions,
                "competitions",
                new { controller = "competitions", action = "index" }
            );

            routes.MapRoute(
                RouteName.Competition,
                "competitions/{id}",
                new { controller = "competitions", action = "index" }
            );

            routes.MapRoute(
                RouteName.Management,
                "management",
                new { controller = "management", action = "index" }
            );

            routes.MapRoute(
                RouteName.History,
                "history",
                new { controller = "history", action = "index" }
            );

            routes.MapRoute(
                RouteName.HistoryItem,
                "history/{id}",
                new { controller = "history", action = "index" }
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
                RouteName.UserLogin,
                "login",
                new { controller = "user", action = "login" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
