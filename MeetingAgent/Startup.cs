using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingAgent.Startup))]
namespace MeetingAgent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
