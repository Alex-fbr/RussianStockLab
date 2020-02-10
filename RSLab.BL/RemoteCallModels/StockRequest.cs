using System;
using System.ComponentModel.DataAnnotations;

namespace RSLab.BL.RemoteCallModels
{
    public class StockRequest
    {
        [Required]
        [StringLength(maximumLength:6,MinimumLength =2)]
        public string SecidOfStock { get; set; } = "LKOH";

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; } = DateTime.Now;  
    }
}