using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class LfldetailHistory
    {
        public int Id { get; set; }
        public DateTime LoadingDate { get; set; }
        public DateTime OnDate { get; set; }
        public int StockId { get; set; }
        public decimal? TsumCcWtPeriod { get; set; }
        public decimal? TsumCcWtYearAgo { get; set; }
        public decimal? ProfitPerc { get; set; }
    }
}
