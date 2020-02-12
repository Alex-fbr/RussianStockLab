using Microsoft.EntityFrameworkCore;
using RSLab.DAL.Entities;

namespace RSLab.DAL.Internal.Implementation
{
    public class StockDbContext : DbContext, IStockDbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {

        }
   
        public DbSet<Stock> Stocks { get;set;}
    }
}
