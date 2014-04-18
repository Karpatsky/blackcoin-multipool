using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackCoinMultipool.Core.Model
{
    public class Statistics
    {
        public string Address { get; set; }

        public double HashRateScrypt { get; set; }
        public double HashRateSHA256 { get; set; }

        public long CurrentSharesScrypt { get; set; }
        public long CurrentSharesSHA256 { get; set; }

        public double LatestPayoutScrypt { get; set; }
        public double LatestPayoutSHA256 { get; set; }

        public List<Shift> Shifts { get; set; }
    }
}
