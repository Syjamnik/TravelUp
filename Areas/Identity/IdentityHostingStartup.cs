using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TravelUp.Areas.Identity.IdentityHostingStartup))]
namespace TravelUp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}