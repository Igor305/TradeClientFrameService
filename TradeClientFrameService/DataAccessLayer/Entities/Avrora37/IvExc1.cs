﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class IvExc1
    {
        public long? ChId { get; set; }
        public DateTime? DocDate { get; set; }
        public long? DocId { get; set; }
        public short? CodeId4 { get; set; }
        public string CodeName4 { get; set; }
        public long? RlogDocId { get; set; }
        public int? StockId { get; set; }
        public string StockName { get; set; }
        public int? NewStockId { get; set; }
        public string NewStockName { get; set; }
        public int? TranStockId { get; set; }
        public string TranStockName { get; set; }
        public string BarCode { get; set; }
        public int? ProdId { get; set; }
        public string ProdName { get; set; }
        public string Um { get; set; }
        public decimal Tqty { get; set; }
        public decimal TnewQty { get; set; }
        public decimal PriceMc { get; set; }
        public decimal TsumCc { get; set; }
        public decimal TnewSumCc { get; set; }
        public decimal? DiffQty { get; set; }
        public decimal? DiffSum { get; set; }
        public decimal TrecSumCc { get; set; }
        public decimal TnewRecSumCc { get; set; }
        public decimal? DiffRecSum { get; set; }
        public string EmpName { get; set; }
        public int? WempId { get; set; }
        public int? WteamId { get; set; }
        public long? DisDocId { get; set; }
        public string IntDocId { get; set; }
    }
}
