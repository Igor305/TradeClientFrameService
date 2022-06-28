﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class POpwrk
    {
        public long ChId { get; set; }
        public long DocId { get; set; }
        public int WorderId { get; set; }
        public DateTime DocDate { get; set; }
        public decimal KursMc { get; set; }
        public int OurId { get; set; }
        public short CodeId1 { get; set; }
        public short CodeId2 { get; set; }
        public short CodeId3 { get; set; }
        public short CodeId4 { get; set; }
        public short CodeId5 { get; set; }
        public short PayTypeId { get; set; }
        public string OrderNotes { get; set; }
        public string Notes { get; set; }
        public string IntDocId { get; set; }
        public int StateCode { get; set; }
    }
}
