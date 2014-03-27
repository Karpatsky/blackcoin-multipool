using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackCoinMultipool.Core.Model
{
    public class Statistics
    {
        public string Address { get; set; }

        public double HashRate { get; set; }
        public double AverageHashRate { get; set; }



        public double TotalProfit { get; set; }
        public double Last24hProfit { get; set; }
        public int MiningDays { get; set; }
        public int LastPayout { get; set; }
        public DateTimeOffset Joined { get; set; }

        public double Immature { get; set; }
        public double Unexchanged { get; set; }
        public double ReadyForPayout { get; set; }
        public double TotalExpected { get; set; }

    }
}
