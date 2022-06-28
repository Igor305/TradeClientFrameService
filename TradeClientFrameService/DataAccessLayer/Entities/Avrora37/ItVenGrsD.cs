using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItVenGrsD
    {
        public long ChId { get; set; }
        public int StockId { get; set; }
        public decimal Total { get; set; }
        public string PgrIdlist { get; set; }
        public DateTime Docdate { get; set; }
        public short CodeId3 { get; set; }
        public string PcatCmIdlist { get; set; }
    }
}
