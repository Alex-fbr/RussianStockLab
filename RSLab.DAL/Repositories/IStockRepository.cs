using RSLab.DAL.Entities;
using RSLab.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSLab.DAL.Repositories
{
    public interface IStockRepository: IBaseRepository<Stock>
    {
        Stock GetById(int id);
        Task<Stock> GetByIdAsync(int id);
        IEnumerable<Stock> Stocks { get;}
        Task<Stock> GetBySecIdAndDate(string secId, DateTime date);
    }
}
