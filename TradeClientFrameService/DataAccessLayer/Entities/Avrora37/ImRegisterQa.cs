﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ImRegisterQa
    {
        public int Id { get; set; }
        public long InvoiceId { get; set; }
        public int ProdId { get; set; }
        public int? Qty { get; set; }
        public DateTime? ImportDate { get; set; }
        public string FileValue { get; set; }
        public bool? IsCheck { get; set; }
    }
}
