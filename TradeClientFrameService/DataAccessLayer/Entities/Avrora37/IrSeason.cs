using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class IrSeason
    {
        public int PgrId { get; set; }
        public string Notes { get; set; }
        public DateTime ForderDate { get; set; }
        public DateTime? ShptDate { get; set; }
        public DateTime? Recarrdate { get; set; }
        public DateTime? Arrdate { get; set; }
        public DateTime? СonfirmDate { get; set; }
        public long ChId { get; set; }
    }
}
