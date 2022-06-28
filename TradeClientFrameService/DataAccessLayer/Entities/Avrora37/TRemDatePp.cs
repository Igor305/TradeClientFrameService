﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class TRemDatePp
    {
        public int OurId { get; set; }
        public int StockId { get; set; }
        public int SecId { get; set; }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string Um { get; set; }
        public decimal? RemQty { get; set; }
        public decimal? PriceMc { get; set; }
        public decimal? RemSumMc { get; set; }
        public decimal? PriceCc { get; set; }
        public decimal? RemSumCc { get; set; }
        public int Ppid { get; set; }
        public int CompId { get; set; }
        public int PcatId { get; set; }
        public int PgrId { get; set; }
        public int PgrId1 { get; set; }
        public int PgrId2 { get; set; }
        public int PgrId3 { get; set; }
        public short PgrAid { get; set; }
        public short PbgrId { get; set; }
    }
}
