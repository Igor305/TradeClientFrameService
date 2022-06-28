using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class CashOperationForAnalyticsByMonth
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int StockId { get; set; }
        public decimal? SaleDayCount { get; set; }
        public decimal? SaleSumInCashAndCard { get; set; }
        public decimal? SaleSumInBonuses { get; set; }
        public decimal? CrretSumInCashAndCard { get; set; }
        public decimal? CrretSumInBonuses { get; set; }
        public DateTime? PeriodBetweenVenDateStartDate { get; set; }
        public DateTime? PeriodBetweenVenDateFinishDate { get; set; }
        public decimal? BetweenVenDateSaleSumInCashAndCard { get; set; }
        public decimal? BetweenVenDateSaleSumInBonuses { get; set; }
        public decimal? BetweenVenDateCrretSumInCashAndCard { get; set; }
        public decimal? BetweenVenDateCrretSumInBonuses { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
