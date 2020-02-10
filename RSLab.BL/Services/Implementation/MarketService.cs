using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RSLab.BL.Common;
using RSLab.BL.Models;
using RSLab.BL.RemoteCallModels;
using RSLab.DAL.Enums;
using RSLab.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RSLab.BL.Services.Implementation
{
    public class MarketService : IMarketService
    {
        private readonly string url = "http://iss.moex.com/iss/engines/stock/markets/shares/boards/TQBR/securities.json";
        private readonly string urlHistory = "http://iss.moex.com/iss/history/engines/stock/markets/shares/boards/TQBR/securities/";
        private readonly IStockRepository _stockRepository;

        public MarketService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        
        public List<MSCIModel> GetStockOfMSCI()
        {
            var allStocks = GetAllStocks();
            var stocksOfMSCI = TransformToMSCI(allStocks);
            return stocksOfMSCI;
        }

        public Dictionary<string, TQBRModel> GetAllStocks()
        {
            var answer = new Dictionary<string, TQBRModel>();
            try
            { 
                string responseAnswer;

                var request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseAnswer = reader.ReadToEnd();
                            reader.Close();
                            stream.Close();
                            response.Close();
                        }
                    }
                }

                var allStocks = TryParseStringToListOfTQBRModel(responseAnswer);
                foreach (var item in allStocks)
                {
                    answer.Add(item.Key, item.Value);
                }

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "ERROR");
                throw;
            }
            return answer;

        }


        private string GetColorByPercent(double? perc)
        {
            string result;
            switch (perc)
            {
                case double p when p > 0.25:
                    result = "success";
                    break;
                case double p when p < -0.25:
                    result = "danger";
                    break;
                case double p when (p <= 0.25 && p >= -0.25):
                    result = "secondary";
                    break;
                default:
                    result = "dark";
                    break;
            }

            return result;
        }

        private List<string> GetListNameOfMSCIStocks()
        {
            var answer = new List<string>()
            {
               "LKOH","SBER","SIBN","TATN","NVTK","GMKN","ROSN","MAGN","SNGSP","ALRS","MTSS",
               "FIVE","CHMF","SNGS","NLMK","IRAO","PLZL","MOEX","VTBR","POLY","PHOR","MGNT","TRNFP"
            };
            return answer;
        }

        private IndustrialSectorEnum GetIndustrialSectroBySECID(string secid)
        {
            if (!string.IsNullOrEmpty(secid))
            {
                if (SortedListOfStocksByIndustrialSector.Telecommunicators.Contains(secid)) return IndustrialSectorEnum.Telecommunication;
                if (SortedListOfStocksByIndustrialSector.Chemicals.Contains(secid)) return IndustrialSectorEnum.Chemicals;
                if (SortedListOfStocksByIndustrialSector.Consumers.Contains(secid)) return IndustrialSectorEnum.Consumer;
                if (SortedListOfStocksByIndustrialSector.ElectricUtilities.Contains(secid)) return IndustrialSectorEnum.Electric;
                if (SortedListOfStocksByIndustrialSector.Financials.Contains(secid)) return IndustrialSectorEnum.Financials;
                if (SortedListOfStocksByIndustrialSector.MetalsAndMining.Contains(secid)) return IndustrialSectorEnum.Metals;
                if (SortedListOfStocksByIndustrialSector.OilAndGas.Contains(secid)) return IndustrialSectorEnum.OilAndGas;
                if (SortedListOfStocksByIndustrialSector.Telecommunicators.Contains(secid)) return IndustrialSectorEnum.Telecommunication;
                if (SortedListOfStocksByIndustrialSector.Transports.Contains(secid)) return IndustrialSectorEnum.Transport;
            }
            return IndustrialSectorEnum.Unknown; 
        }

        private Dictionary<string, TQBRModel> TryParseStringToListOfTQBRModel(string responseString)
        {
            var stockList = new Dictionary<string, TQBRModel>();
            try
            {
                JObject search = JObject.Parse(responseString);

                IList<JToken> securities = search["securities"]["data"].Children().ToList();
                foreach (JToken secur in securities)
                {
                    IList<JToken> cur = secur.Children().ToList();
                    var searchResult = new TQBRModel
                    {
                        IndustrialSector = GetIndustrialSectroBySECID(cur[0]?.Value<string>()),
                        DinamicData = new MarketData(),

                        StaticData = new Securities()
                        {
                            SECID = cur[0]?.Value<string>() ?? null,
                            BOARDID = cur[1]?.Value<string>() ?? null,
                            SHORTNAME = cur[2]?.Value<string>() ?? null,
                            PREVPRICE = cur[3]?.Value<double?>() ?? null,
                            LOTSIZE = cur[4]?.Value<int?>() ?? null,
                            FACEVALUE = cur[5]?.Value<double?>() ?? null,
                            STATUS = cur[6]?.Value<string>() ?? null,
                            BOARDNAME = cur[7]?.Value<string>() ?? null,
                            DECIMALS = cur[8]?.Value<int?>() ?? null,
                            SECNAME = cur[9]?.Value<string>() ?? null,
                            REMARKS = cur[10]?.Value<string>() ?? null,
                            MARKETCODE = cur[11]?.Value<string>() ?? null,
                            INSTRID = cur[12]?.Value<string>() ?? null,
                            SECTORID = cur[13]?.Value<string>() ?? null,
                            MINSTEP = cur[14]?.Value<double?>() ?? null,
                            PREVWAPRICE = cur[15]?.Value<double?>() ?? null,
                            FACEUNIT = cur[16]?.Value<string>() ?? null,
                            PREVDATE = cur[17]?.Value<DateTime?>() ?? null,
                            ISSUESIZE = cur[18]?.Value<long?>() ?? null,
                            ISIN = cur[19]?.Value<string>() ?? null,
                            LATNAME = cur[20]?.Value<string>() ?? null,
                            REGNUMBER = cur[21]?.Value<string>() ?? null,
                            PREVLEGALCLOSEPRICE = cur[22]?.Value<double?>() ?? null,
                            PREVADMITTEDQUOTE = cur[23]?.Value<double?>() ?? null,
                            CURRENCYID = cur[24]?.Value<string>() ?? null,
                            SECTYPE = cur[25]?.Value<string>() ?? null,
                            LISTLEVEL = cur[26]?.Value<int?>() ?? null,
                            SETTLEDATE = cur[27]?.Value<DateTime?>() ?? null
                        }

                    };

                    stockList.Add(searchResult.StaticData.SECID, searchResult);
                }

                IList<JToken> marketdata = search["marketdata"]["data"].Children().ToList();
                foreach (JToken data in marketdata)
                {
                    IList<JToken> st = data.Children().ToList();
                    if (st != null)
                    {
                        var secId = st[0]?.Value<string>() ?? null;

                        if (st[45]?.Value<double?>() != null) stockList[secId].DinamicData.PRICEMINUSPREVWAPRICE = st[45]?.Value<double?>() ?? null;
                        else stockList[secId].DinamicData.PRICEMINUSPREVWAPRICE = null;

                        if (st[12]?.Value<double?>() != null) stockList[secId].DinamicData.LAST = st[12]?.Value<double?>() ?? null;
                        else stockList[secId].DinamicData.LAST = null;

                        if (st[18]?.Value<double?>() != null) stockList[secId].DinamicData.WAPRICE = st[18]?.Value<double?>() ?? null;
                        else stockList[secId].DinamicData.WAPRICE = null;

                        if (st[20]?.Value<double?>() != null) stockList[secId].DinamicData.WAPTOPREVWAPRICEPRCNT = st[20]?.Value<double?>() ?? null;
                        else stockList[secId].DinamicData.WAPTOPREVWAPRICEPRCNT = null;
                    }
                   
                }

                return stockList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "ERROR");
                throw;
            }


        }

        private List<MSCIModel> TransformToMSCI(Dictionary<string, TQBRModel> allStocks)
        {
            var ret = new List<MSCIModel>();
            try
            {
                List<string> listNameOfMSCIStocks = GetListNameOfMSCIStocks();

                foreach (var item in listNameOfMSCIStocks)
                {
                    var stock = allStocks.FirstOrDefault(x => x.Key == item);
                    if (stock.Value != null)
                    {
                        var perc = stock.Value.DinamicData.WAPTOPREVWAPRICEPRCNT;
                        ret.Add(new MSCIModel()
                        {
                            CompanyName = stock.Value.StaticData.SECNAME.Trim(new char[] { '"', '/', '\\' }),
                            SECID = stock.Value.StaticData.SECID,
                            ColorCard = GetColorByPercent(perc),
                            PredPrice = stock.Value.StaticData.PREVLEGALCLOSEPRICE,
                            CurrentPrice = stock.Value.DinamicData.WAPRICE, 
                            PercentChange = perc,
                            IndustrialSector = stock.Value.IndustrialSector
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "ERROR");
                throw;

            }
            return ret;
        }
   
        public async Task GetAndSaveStock(StockRequest req)
        {
            try
            {
                string responseAnswer;
                string url = urlHistory + $"{req.SecidOfStock}.json?from={req.DateFrom:yyyy-MM-dd}&till={req.DateFrom.AddMonths(1):yyyy-MM-dd}";

                var request = (HttpWebRequest)WebRequest.Create(url);
     
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseAnswer = reader.ReadToEnd();
                            reader.Close();
                            stream.Close();
                            response.Close();
                        }
                    }
                }

                var allStocks = TryParseHistoryToListOfTQBRModel(responseAnswer);

                await SaveStocksToDataBaseAsync(allStocks);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "ERROR");
                throw;
            }
        }

        private async Task SaveStocksToDataBaseAsync(List<HistoryStockModel> allStocks)
        {
            foreach (var item in allStocks)
            {
                try
                {
                    var st = await _stockRepository.GetBySecIdAndDate(item.SecId, item.CurrentDate);
                    if (st == null)
                    {
                        await _stockRepository.InsertAsync(new DAL.Entities.Stock()
                        {
                            ClosePrice = item.ClosePrice,
                            CurrentDate = item.CurrentDate,
                            HighPrice = item.HighPrice,
                            IndustrialSector = item.IndustrialSector,
                            LowPrice = item.LowPrice,
                            OpenPrice = item.OpenPrice,
                            SECID = item.SecId,
                            SHORTNAME = item.ShortName,
                            WaPrice = item.WaPrice
                        });
                    }
                    else 
                    {
                        st.ClosePrice = item.ClosePrice;
                        st.CurrentDate = item.CurrentDate;
                        st.HighPrice = item.HighPrice;
                        st.IndustrialSector = item.IndustrialSector;
                        st.LowPrice = item.LowPrice;
                        st.OpenPrice = item.OpenPrice;
                        st.SECID = item.SecId;
                        st.SHORTNAME = item.ShortName;
                        st.WaPrice = item.WaPrice;
                        await _stockRepository.UpdateAsync(st);
                    }
                  
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message, 
                        $"Не смог записать в базу запись {JsonConvert.SerializeObject(item)}");
                    continue;
                }
            }
        }

        private List<HistoryStockModel> TryParseHistoryToListOfTQBRModel(string responseString)
        {
            var stockList = new List<HistoryStockModel>();
            try
            {
                JObject search = JObject.Parse(responseString);

                IList<JToken> securities = search["history"]["data"].Children().ToList();
                foreach (JToken secur in securities)
                {
                    IList<JToken> cur = secur.Children().ToList();
                    var searchResult = new HistoryStockModel
                    {
                        IndustrialSector = GetIndustrialSectroBySECID(cur[3]?.Value<string>()),
                        SecId = cur[3]?.Value<string>() ?? null,
                        ShortName = cur[2]?.Value<string>() ?? null,
                        CurrentDate = cur[1]?.Value<DateTime?>() ?? new DateTime(1,1,1),
                        HighPrice = cur[8]?.Value<double?>() ?? 0,
                        LowPrice = cur[7]?.Value<double?>() ?? 0,
                        ClosePrice = cur[11]?.Value<double?>() ?? 0,
                        OpenPrice = cur[6]?.Value<double?>() ?? 0,
                        WaPrice = cur[10]?.Value<double?>() ?? 0,
                    };

                    stockList.Add(searchResult);
                }

                return stockList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, "ERROR");
                throw;
            }


        }

    }
}
