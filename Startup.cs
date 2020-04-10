using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelUp.Data;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Email;
using TravelUp.Services;

namespace TravelUp
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
            #region cookie
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.PostConfigure<CookieAuthenticationOptions>(
                IdentityConstants.ApplicationScheme,
                opt =>
                {
                    opt.LoginPath = "/identity/account/Login";
                    opt.AccessDeniedPath = "/identity/account/AccessDenied";
                    opt.LogoutPath = "/identity/account/Logout";
                }
                );
            #endregion

            // konieczne gdy chcemy u¿ywaæ IdentityApplicationDBContext
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

/*            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();*/
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthentication().AddFacebook(x => {
                x.AppId = Configuration.GetConnectionString("FacebookAppId");
                x.AppSecret = Configuration.GetConnectionString("FacebookAppSecret");
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbUserQueries,DbUserQueries>();
            services.AddScoped<IDbTravelQueries, DbTravelQueries>();
            services.AddScoped<IDbFavouriteMTMQueries, DbFavouriteMTMQueries>();
            services.AddScoped<IDbVisitedMTMQueries, DbVisitedMTMQueries>();
            
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);
            services.AddSingleton<ICalculateRating, CalculateRating>();




            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
