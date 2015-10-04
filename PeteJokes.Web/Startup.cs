using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.Windsor;
using Owin;
using PeteJokes.Web.Infrastructure;

namespace PeteJokes.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var container = new WindsorContainer();
            container.Install(
                new ServicesInstaller(),
                new ControllersInstaller());

            var config = new HttpConfiguration();
            config.Services.Replace(typeof (IHttpControllerActivator), new WindsorControllerActivator(container));
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApiRoute",
                "api/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = RouteParameter.Optional});

            appBuilder.UseWebApi(config);
        }
    }
}