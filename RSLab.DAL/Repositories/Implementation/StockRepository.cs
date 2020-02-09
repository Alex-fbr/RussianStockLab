using Microsoft.EntityFrameworkCore;
using RSLab.DAL.Entities;
using RSLab.DAL.Internal;
using RSLab.EntityFramework.Implementation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSLab.DAL.Repositories.Implementation
{
    public class StockRepository :  BaseRepository<Stock>, IStockRepository
    {
        private readonly IStockDbContext _stockDbContext;

        public StockRepository(IStockDbContext stockDbContext) : base(stockDbContext.Stocks)
        {
            _stockDbContext = stockDbContext;
        }

        
        public IEnumerable<Stock> Stocks => _stockDbContext.Stocks;


        public Stock GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Stock> GetBySecIdAndDate(string secId, DateTime date)
        {
           return await DbSet.SingleOrDefaultAsync(x => x.SECID == secId && x.CurrentDate == date);
        }
    }
}
