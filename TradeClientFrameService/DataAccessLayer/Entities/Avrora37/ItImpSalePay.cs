﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItImpSalePay
    {
        public long ChId { get; set; }
        public int SrcPosId { get; set; }
        public int PayFormCode { get; set; }
        public decimal SumCcWt { get; set; }
        public string Notes { get; set; }
        public int PospayId { get; set; }
        public int? PospayDocId { get; set; }
        public string PospayRrn { get; set; }
        public string ChequeText { get; set; }
        public int BservId { get; set; }
        public int? PayPartsQty { get; set; }
        public string ContractNo { get; set; }
        public string PospayText { get; set; }
        public byte Status { get; set; }
    }
}
