﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class TRemDay
    {
        public int ChId { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime CalcDate { get; set; }
    }
}
