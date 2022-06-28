﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class BTranE
    {
        public long ChId { get; set; }
        public int OurId { get; set; }
        public DateTime? DocDate { get; set; }
        public int EmpId { get; set; }
        public short CurrId { get; set; }
        public decimal SumAc { get; set; }
        public decimal TaxSum { get; set; }
        public decimal SumAcNt { get; set; }
        public decimal KursMc { get; set; }
        public decimal KursCc { get; set; }
        public short CodeId1 { get; set; }
        public short CodeId2 { get; set; }
        public short CodeId3 { get; set; }
        public short CodeId4 { get; set; }
        public short CodeId5 { get; set; }
        public int GoperId { get; set; }
        public int GtranId { get; set; }
        public decimal SumAc1 { get; set; }
        public decimal TaxSum1 { get; set; }
        public decimal SumAc1Nt { get; set; }
        public long? InDocId { get; set; }
        public string Notes { get; set; }
        public int StateCode { get; set; }
    }
}
