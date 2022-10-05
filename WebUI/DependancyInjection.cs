using System;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebUI
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplictionDb(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            service.AddDatabaseDeveloperPageExceptionFilter();

            service.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return service;
        }
    }
}

