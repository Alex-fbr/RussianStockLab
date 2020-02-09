using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSLab.DAL.Entities
{
    [Table("Stocks",Schema ="dbo")]
    public class Stock
    {
        [Required]
        public int Id { get; set; }
        public string SECID { get; set; }
        public string SHORTNAME { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }
        public double LowPrice { get; set; }
        public double HighPrice { get; set; }
        public double WaPrice { get; set; }
        public DateTime CurrentDate { get; set; }
       // public IndustrialSectorEnum IndustrialSector { get; set; }

    }
}
