﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItDayRemD
    {
        public long ChId { get; set; }
        public int OurId { get; set; }
        public int StockId { get; set; }
        public int SecId { get; set; }
        public int ProdId { get; set; }
        public int Ppid { get; set; }
        public decimal Qty { get; set; }
        public decimal AccQty { get; set; }
    }
}
