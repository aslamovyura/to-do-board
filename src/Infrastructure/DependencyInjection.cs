using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DB Context.

            // Add Services.
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddTransient<IDateTimeService, DateTimeService>();

            // Add Identity.
            //services.AddDefaultIdentity<ApplicationUser>()
            //        .AddRoles<IdentityRole>()
            //        .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentityServer()
            //        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
    }
}