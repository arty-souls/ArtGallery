using System;
using ArtGallery.Areas.Identity.Data;
using ArtGallery.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ArtGallery.Areas.Identity.IdentityHostingStartup))]
namespace ArtGallery.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ArtGalleryDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ArtGalleryDbContextConnection")));

                services.AddDefaultIdentity<ArtGalleryUser>(options => options.SignIn.RequireConfirmedAccount =false)
                    .AddEntityFrameworkStores<ArtGalleryDbContext>();
            });
        }
    }
}