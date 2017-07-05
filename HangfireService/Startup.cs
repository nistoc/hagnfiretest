using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangfireService.Startup))]

namespace HangfireService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=(localdb)\mssqllocaldb; Database=testHangFire01; trusted_connection=false;user=HangFire;password=pass@123");

            //app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}