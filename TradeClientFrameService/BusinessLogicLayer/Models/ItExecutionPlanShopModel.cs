﻿using System;

namespace BusinessLogicLayer.Models
{
    public class ItExecutionPlanShopModel
    {
        public DateTime Dates { get; set; }
        public int StockId { get; set; }
        public decimal? PlanDay { get; set; }
        public decimal? FactDay { get; set; }
        public decimal? PercentForDay { get; set; }
        public decimal? PlanMonth { get; set; }
        public decimal? FactMonth { get; set; }
        public decimal? PercentForMonth { get; set; }
        public decimal? PercentForecast { get; set; }
    }
}
