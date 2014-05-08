using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(verklegt.Startup))]
namespace verklegt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
