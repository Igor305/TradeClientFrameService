using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer
{
    public partial class TempDistributionQtyD
    {
        public long? AchId { get; set; }
        public int? DetSrcPosId { get; set; }
        public decimal? DistributionQtyD { get; set; }
        public int Cnt { get; set; }
    }
}
