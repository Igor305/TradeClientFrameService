﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class BSinvD
    {
        public long ChId { get; set; }
        public int SrcPosId { get; set; }
        public int AssId { get; set; }
        public decimal SumCcNt { get; set; }
        public decimal TaxSum { get; set; }
        public decimal SumCcWt { get; set; }
        public int GoperId { get; set; }
        public int GtranId { get; set; }
        public decimal GposTsumWt { get; set; }
        public decimal GposTtaxSum { get; set; }
    }
}
