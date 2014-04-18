using BlackCoinMultipool.Core.Service;
using BlackCoinMultipool.UI.WindowsPhone.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.UI.WindowsPhone.Service
{
    public class CommonService : ICommonService
    {
        public string DonationAddress
        {
            get { return "BM4mL6tSo9EphkrnNBppzhjg5GsCXa9C2e"; }
        }    

        public string PopupOk
        {
            get
            {
                return AppResources.ResourceManager.GetString("PopupOK", AppResources.Culture);
            }
        }

        public string PopupYes
        {
            get
            {
                return AppResources.ResourceManager.GetString("PopupYes", AppResources.Culture);
            }
        }

        public string PopupNo
        {
            get
            {
                return AppResources.ResourceManager.GetString("PopupNo", AppResources.Culture);
            }
        }

        public string PopupFoundAddress
        {
            get
            {
                return AppResources.ResourceManager.GetString("PopupFoundAddress", AppResources.Culture);
            }
        }

        public string PopupIsThisCorrect
        {
            get
            {
                return AppResources.ResourceManager.GetString("PopupIsThisCorrect", AppResources.Culture);
            }
        }


        public string GettingStartedQRCodePopupText
        {
            get
            {
                return AppResources.ResourceManager.GetString("GettingStartedQRCodePopupText", AppResources.Culture);
            }
        }


        public string StatisticsDay
        {
            get
            {
                return AppResources.ResourceManager.GetString("StatisticsDay", AppResources.Culture);
            }
        }

        public string StatisticsDays
        {
            get
            {
                return AppResources.ResourceManager.GetString("StatisticsDays", AppResources.Culture);
            }
        }

        public string BTC
        {
            get
            {
                return AppResources.ResourceManager.GetString("BTC", AppResources.Culture);
            }
        }

        public string BC
        {
            get
            {
                return AppResources.ResourceManager.GetString("BC", AppResources.Culture);
            }
        }

        public string StatisticsAgo
        {
            get
            {
                return AppResources.ResourceManager.GetString("StatisticsAgo", AppResources.Culture);
            }
        }
    }
}
