using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class ItLogisticsResultsHistory
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public string ColName { get; set; }
        public string DataName { get; set; }
        public decimal? DataQty { get; set; }
    }
}
