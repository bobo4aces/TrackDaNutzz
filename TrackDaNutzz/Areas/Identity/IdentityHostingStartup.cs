using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TrackDaNutzz.Areas.Identity.IdentityHostingStartup))]
namespace TrackDaNutzz.Areas.Identity
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