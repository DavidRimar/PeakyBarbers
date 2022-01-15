using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeakyBarbers.BLL.Services;
using PeakyBarbers.Data;
using PeakyBarbers.Data.Entities;
using PeakyBarbers.Data.SeedData;
using PeakyBarbers.Web.Settings;
using PeakyBarbers.Web.WebServices;
using System;
using System.Security.Claims;

namespace PeakyBarbers.Web
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
            // DBCONTEXT
            services.AddDbContext<PeakyBarbersDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PeakyBarbersLocalDB")));

            // IDENTITY
            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<PeakyBarbersDbContext>()
                .AddDefaultTokenProviders();

            // CONFIGURE IDENTITY OPTIONS
            services.Configure<IdentityOptions>(options => {

                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
            });

            // CONFIGURE COOKIES
            services.ConfigureApplicationCookie(options => {

                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // BLL SERVICES
            services.AddScoped<BarbersService>();
            services.AddScoped<BookingService>();
            services.AddScoped<ServicesService>();

            // USER and ROLE SEEDING
            services.AddScoped<IRoleSeedService, RoleSeedService>();
            services.AddScoped<IUserSeedService, UserSeedService>();

            // MAIL SETTINGS
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            // AUTHENTICATION: GOOGLE
            services.AddAuthentication().AddGoogle(options => {
                IConfigurationSection googleAuth = Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuth["ClientId"];
                options.ClientSecret = googleAuth["ClientSecret"];
            });

            // AUTHORISATION
            services.AddAuthorization(options => {
                options.AddPolicy("Barber", policy => policy.RequireClaim(ClaimTypes.Role, "Barber"));
                options.AddPolicy("RequireBarberRole", policy => policy.RequireRole("Barber"));

                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            // RAZOR PAGES
            services.AddRazorPages(options => {

                // appointments
                options.Conventions.AuthorizePage("/Booking/AppointmentCreate", "RequireBarberRole"); // non-Admin Barber creates his own, Admin Barber creates his own
                options.Conventions.AuthorizePage("/Booking/AppointmentDelete", "RequireBarberRole"); // non-Admin Barber deletes his own, Admin can delete for all (done in BLL)

                // services
                options.Conventions.AuthorizePage("/Services/ServiceCreate", "RequireAdminRole"); // only Admin can create a Service
                options.Conventions.AuthorizePage("/Services/ServiceDelete", "RequireAdminRole"); // only Admin can delete a Service
                options.Conventions.AuthorizePage("/Services/ServiceEdit", "RequireAdminRole"); // only Admin can edit a Service

                // barbers
                options.Conventions.AuthorizePage("/Barbers/BarberCreate", "RequireAdminRole"); // only Admin can create a Barber
                options.Conventions.AuthorizePage("/Barbers/BarberDelete", "RequireAdminRole"); // only Admin can delete a Barber
                options.Conventions.AuthorizePage("/Barbers/BarberEdit", "RequireAdminRole"); // only Admin can edit a Barber
            });

            
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
