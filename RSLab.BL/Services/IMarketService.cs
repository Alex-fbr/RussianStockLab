using RSLab.BL.Models;
using RSLab.BL.RemoteCallModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSLab.BL.Services
{
    public interface IMarketService
    {
        Dictionary<string, TQBRModel> GetAllStocks();
        List<MSCIModel> GetStockOfMSCI();
        Task GetAndSaveStock(StockRequest request);
    }
}
