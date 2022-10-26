using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public Int64 StockCode { get; set; }
        public decimal LastPrice { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}