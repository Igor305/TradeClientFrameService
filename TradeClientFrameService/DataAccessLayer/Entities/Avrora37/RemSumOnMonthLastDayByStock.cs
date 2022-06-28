using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class RemSumOnMonthLastDayByStock
    {
        public DateTime Date { get; set; }
        public int StockId { get; set; }
        public decimal? RemSumCcIn { get; set; }
    }
}
