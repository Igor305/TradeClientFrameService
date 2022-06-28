﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class IvEoprepDoff
    {
        public long ChId { get; set; }
        public int SrcPosId { get; set; }
        public int ProdId { get; set; }
        public string Um { get; set; }
        public decimal PriceAc { get; set; }
        public decimal Qty { get; set; }
        public decimal ExpQty { get; set; }
        public decimal SumAc { get; set; }
        public decimal NewQty { get; set; }
        public decimal NewSumAc { get; set; }
        public decimal RemQty { get; set; }
        public string BarCode { get; set; }
        public int SecId { get; set; }
        public decimal ForeCastQty { get; set; }
        public DateTime? PosExpDate { get; set; }
        public int NremDays { get; set; }
        public long AchId { get; set; }
        public decimal Extra { get; set; }
        public decimal PriceCc { get; set; }
        public decimal TransQty { get; set; }
        public decimal Eoqty { get; set; }
        public decimal RecQty { get; set; }
        public decimal ExcQty { get; set; }
        public decimal SaleQty { get; set; }
        public decimal BremQty { get; set; }
        public decimal EremQty { get; set; }
        public bool BringRange { get; set; }
        public int PgrId3 { get; set; }
        public decimal StockQty { get; set; }
        public decimal NewPriceAc { get; set; }
        public decimal NewPriceCc { get; set; }
        public decimal MarginSumCc { get; set; }
        public string Notes { get; set; }
        public decimal InStockQty { get; set; }
    }
}
