using Microsoft.EntityFrameworkCore;
using RSLab.DAL.Entities;

namespace RSLab.DAL.Internal
{
    public interface IStockDbContext
    {
        DbSet<Stock> Stocks { get; set; }
    }
}
