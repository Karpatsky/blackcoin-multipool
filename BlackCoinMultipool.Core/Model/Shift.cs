using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Model
{
    public class Shift
    {
        public string Timestamp { get; set; }

        public long Shares { get; set; }
        public long TotalShares { get; set; }

        public double AverageHashrate { get; set; }
        public double Profitability { get; set; }
        public double BlackCoinSent { get; set; }
        public bool PayedOut { get; set; }

    }
}
