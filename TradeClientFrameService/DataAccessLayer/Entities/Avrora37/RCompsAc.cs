﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class RCompsAc
    {
        public int CompId { get; set; }
        public int BankId { get; set; }
        public string CompAccountAc { get; set; }
        public bool DefaultAccount { get; set; }
        public string Notes { get; set; }
        public string Ibancode { get; set; }
    }
}
