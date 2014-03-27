using BlackCoinMultipool.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Service
{
    public interface IBlackCoinMultipoolService
    {
        Task<Statistics> GetStatistics(string bitcoinAddress);
    }
}
