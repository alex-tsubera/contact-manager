using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContactManager_v._1._0.Startup))]
namespace ContactManager_v._1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
