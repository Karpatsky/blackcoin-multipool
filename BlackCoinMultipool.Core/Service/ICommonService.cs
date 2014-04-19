using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Service
{
    public interface ICommonService
    {
        string DonationAddressBlackcoin { get; }
        string DonationAddressBitcoin { get; }


        // translation strings that are required in the Core
        string PopupOk { get; }
        string PopupYes { get; }
        string PopupNo { get; }
        string PopupFoundAddress { get; }
        string PopupIsThisCorrect { get; }
        string GettingStartedQRCodePopupText { get; }

        string StatisticsDay { get; }
        string StatisticsDays { get; }
        string BTC { get; }
        string BC { get; }
        string StatisticsAgo { get; }
    }
}
