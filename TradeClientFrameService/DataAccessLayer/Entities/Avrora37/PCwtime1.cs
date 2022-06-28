﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class PCwtime1
    {
        public long ChId { get; set; }
        public long DocId { get; set; }
        public string IntDocId { get; set; }
        public DateTime DocDate { get; set; }
        public decimal KursMc { get; set; }
        public int OurId { get; set; }
        public short CodeId1 { get; set; }
        public short CodeId2 { get; set; }
        public short CodeId3 { get; set; }
        public short CodeId4 { get; set; }
        public short CodeId5 { get; set; }
        public decimal? TchargeCc { get; set; }
        public decimal? TtworkHours { get; set; }
        public decimal? TtruanDaysCount { get; set; }
        public decimal? TtworkDays { get; set; }
        public decimal? TholDaysCount { get; set; }
        public decimal? TsickDaysCount { get; set; }
        public decimal? TbleaveDaysCount { get; set; }
        public decimal? TpleaveDaysCount { get; set; }
        public decimal? TnonAppDaysCount { get; set; }
    }
}
