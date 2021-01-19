using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RSLab.BL.RemoteCallModels;
using RSLab.BL.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DataMining.WebApi.MOEX.Controllers
{
    [Route("api/")]
    [ApiController]
    [ResponseCache(Duration = 60)]
    public class StockController : ControllerBase
    {
        private const int duration = 60;
        private readonly ILogger<StockController> _logger;
        private readonly IMarketService _marketService;
        private IMemoryCache _cache;
        private static IndexStockResponse response = new IndexStockResponse();

        public StockController(IMarketService marketService, IMemoryCache memoryCache, ILogger<StockController> logger)
        {
            _marketService = marketService;
            _cache = memoryCache;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("[controller]/MSCI/get")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = duration)]
        public IndexStockResponse GetStocks(IndexStockRequest query)
        {
            try
            {
                if (!_cache.TryGetValue(query.IndexName, out response))
                {
                    response = new IndexStockResponse
                    {
                        Stocks = _marketService.GetStockOfMSCI()
                    };

                    _cache.Set(query.IndexName, response);
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заявки лидов");
                throw;
            }

        }

        [HttpPost("[controller]/stock/get-history")]
        public async Task<StatusCodeResult> GetAndSaveStock(StockRequest query)
        {
            try
            {
                if (query != null && !string.IsNullOrEmpty(query.SecidOfStock))
                {
                    await _marketService.GetAndSaveStock(query);
                    return Ok();
                }
                else
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заявки лидов");
                return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
            }

        }

        [HttpPost("[controller]/stock/get-history/2017")]
        public async Task<StatusCodeResult> GetAndSaveStockFor2017()
        {
            try
            {
                var mas = new string[] { "LKOH", "SIBN", "TATN", "NVTK", "GMKN", "ROSN", "MAGN", "SNGSP", "ALRS", "MTSS", "FIVE", "CHMF", "SNGS", "NLMK", "IRAO", "PLZL", "MOEX", "VTBR", "POLY", "PHOR", "MGNT", "TRNFP" };

                foreach (var secid in mas)
                {
                    var date = new DateTime(2018, 01, 01);
                    for (int i = 0; i < 12; i++)
                    {
                        var query = new StockRequest()
                        {
                            DateFrom = date,
                            SecidOfStock = secid
                        };
                        await _marketService.GetAndSaveStock(query);
                        date = date.AddMonths(1);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заявки лидов");
                return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
            }

        }
    }
}
