using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BbsSample.Startup))]
namespace BbsSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
