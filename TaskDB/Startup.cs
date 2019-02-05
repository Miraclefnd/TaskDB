using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskDB.Startup))]
namespace TaskDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
