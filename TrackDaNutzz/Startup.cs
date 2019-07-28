using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackDaNutzz.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Readers;
using TrackDaNutzz.Services;
using TrackDaNutzz.Parsers;
using AutoMapper;
using TrackDaNutzz.BindingModels;
using TrackDaNutzz.Services.Import;
using TrackDaNutzz.Services.Statistics;
using TrackDaNutzz.Services.Users;

namespace TrackDaNutzz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<TrackDaNutzzDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<TrackDaNutzzUser, TrackDaNutzzRole>()
                .AddEntityFrameworkStores<TrackDaNutzzDbContext>();
            services.AddAutoMapper(cfg => cfg.AddProfile<HandProfile>(),AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IHandHistoryReader, HandHistoryReader>();
            services.AddTransient<IParser, PokerStarsParser>();
            services.AddTransient<IImportService, ImportService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (TrackDaNutzzDbContext context = new TrackDaNutzzDbContext())
            {
                context.Database.EnsureCreated();
                if (context.Roles.Count() == 0)
                {
                    context.Roles.Add(new TrackDaNutzzRole() { Name = "Admin", NormalizedName = "ADMIN" });
                    context.SaveChanges();
                }
                //if (context.Positions.Count() == 0)
                //{
                //    context.Positions.Add(new Position() { Name = "UTG +3", Type = "Early" });
                //    context.Positions.Add(new Position() { Name = "UTG +2", Type = "Early" });
                //    context.Positions.Add(new Position() { Name = "UTG +1", Type = "Early" });
                //    context.Positions.Add(new Position() { Name = "MP +3", Type = "Middle" });
                //    context.Positions.Add(new Position() { Name = "MP +2", Type = "Middle" });
                //    context.Positions.Add(new Position() { Name = "MP +1", Type = "Middle" });
                //    context.Positions.Add(new Position() { Name = "CO", Type = "Late" });
                //    context.Positions.Add(new Position() { Name = "BU", Type = "Late" });
                //    context.Positions.Add(new Position() { Name = "SB", Type = "Early" });
                //    context.Positions.Add(new Position() { Name = "BB", Type = "Early" });
                //}
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
