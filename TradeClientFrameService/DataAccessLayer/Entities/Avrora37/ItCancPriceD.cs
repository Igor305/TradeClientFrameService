﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItCancPriceD
    {
        public long ChId { get; set; }
        public int ProdId { get; set; }
        public decimal PriceCc { get; set; }
        public string Um { get; set; }
        public int SrcPosId { get; set; }
    }
}
