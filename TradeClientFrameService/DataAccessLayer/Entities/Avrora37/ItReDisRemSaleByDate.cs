﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItReDisRemSaleByDate
    {
        public DateTime? DocDate { get; set; }
        public int? OurId { get; set; }
        public int? StockId { get; set; }
        public int? ProdId { get; set; }
        public decimal? Rem { get; set; }
        public decimal? Sale { get; set; }
    }
}
