using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin;
using OrdiOwin.Core.Filters;
using OrdiOwin.Core.Settings;
using Owin;

[assembly: OwinStartup(typeof(OrdiOwin.Startups.OrdiStartup))]
namespace OrdiOwin.Startups
{
    public class OrdiStartup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif

            HttpConfiguration config = new HttpConfiguration();
            config.Filters.Add(new ExceptionHandlingAttribute());
            config.Filters.Add(new ActionHandlingFilter());
            config.Services.Replace(typeof(IAssembliesResolver), new ExtendedDefaultAssembliesResolver());
            config.Routes.MapHttpRoute(
                name: "DefaultAPi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
            config.Formatters.Remove(config.Formatters.JsonFormatter);

            app.UseWebApi(config);
        }
    }
}
