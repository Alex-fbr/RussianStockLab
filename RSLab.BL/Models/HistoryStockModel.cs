using RSLab.DAL.Enums;
using System;

namespace RSLab.BL.Models
{
    public class HistoryStockModel
    {
        public string SecId { get; set; }
        public string ShortName { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public double LowPrice { get; set; }
        public double HighPrice { get; set; }
        public double WaPrice { get; set; }
        public DateTime CurrentDate { get; set; }
        public IndustrialSectorEnum IndustrialSector { get; set; }
    }
}
