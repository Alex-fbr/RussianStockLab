using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSLab.DAL.Internal;
using RSLab.DAL.Internal.Implementation;
using RSLab.EntityFramework.Implementation;

namespace RSLab.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterStockDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext<IStockDbContext, StockDbContext>(() => configuration.GetConnectionString("StockDB"));
        }
    }
}
