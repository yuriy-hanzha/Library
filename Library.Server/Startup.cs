using Library.Ninject;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Library.Server.Startup))]
namespace Library.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = StartupConfig.Config;

            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}