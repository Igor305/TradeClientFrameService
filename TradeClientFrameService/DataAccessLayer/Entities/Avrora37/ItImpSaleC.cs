﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItImpSaleC
    {
        public long ChId { get; set; }
        public int SrcPosId { get; set; }
        public int ProdId { get; set; }
        public string Um { get; set; }
        public decimal Qty { get; set; }
        public decimal PriceCcNt { get; set; }
        public decimal SumCcNt { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxSum { get; set; }
        public decimal PriceCcWt { get; set; }
        public decimal SumCcWt { get; set; }
        public string BarCode { get; set; }
        public int CreasonId { get; set; }
        public int EmpId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public byte Status { get; set; }
    }
}
