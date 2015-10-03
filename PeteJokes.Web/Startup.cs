using System.Web.Http;
using Owin;

namespace PeteJokes.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApiRoute",
                "api/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = RouteParameter.Optional});

            appBuilder.UseWebApi(config);
        }
    }
}