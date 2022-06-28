﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class PLexp1
    {
        public long ChId { get; set; }
        public long DocId { get; set; }
        public string IntDocId { get; set; }
        public int OurId { get; set; }
        public DateTime DocDate { get; set; }
        public decimal KursMc { get; set; }
        public short CodeId1 { get; set; }
        public short CodeId2 { get; set; }
        public short CodeId3 { get; set; }
        public short CodeId4 { get; set; }
        public short CodeId5 { get; set; }
        public DateTime AccDate { get; set; }
        public byte LexpType { get; set; }
        public byte LexpForm { get; set; }
        public decimal LexpPrc { get; set; }
        public decimal? TlarrSumCc { get; set; }
        public decimal? TlrecSumCc { get; set; }
        public decimal? TlexpSumCc { get; set; }
        public decimal? TldepSumCc { get; set; }
    }
}
