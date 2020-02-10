using System.Collections.Generic;

namespace RSLab.BL.Common
{
    public static class SortedListOfStocksByIndustrialSector
    {
        public static List<string> Chemicals { get; set; } = new List<string>(){ "PHOR" };

        public static List<string> Consumers { get; set; } = new List<string>(){ "FIVE", "MAGN" };

        public static List<string> ElectricUtilities { get; set; } = new List<string>(){ "IRAO" };

        public static List<string> Financials { get; set; } = new List<string>(){ "SBER","MOEX","VTBR" };

        public static List<string> MetalsAndMining { get; set; } = new List<string>(){ "NLMK", "GMKN","MGNT","ALRS","CHMF","POLY","PLZL" };

        public static List<string> OilAndGas { get; set; } = new List<string>(){ "LKOH","TATN","NVTK","ROSN","SNGSP","SNGS","TRNFP","SIBN" };

        public static List<string> Telecommunicators { get; set; } = new List<string>(){ "MTSS", "MGTS", "MGTSP","RTKM","RTKMP" };

        public static List<string> Transports { get; set; } = new List<string>();
    }
}
