using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyLibrary.EntityFramework.Implementation
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext<TContextService, TContextImplementation>(
            this IServiceCollection services,
            Func<string> GetConnectionString,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
                where TContextService : class
                where TContextImplementation : DbContext, TContextService
        {
            services.AddDbContext<TContextImplementation>(options =>
            {
                options.UseSqlServer(GetConnectionString());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<TContextService, TContextImplementation>();
        }
    }
}
