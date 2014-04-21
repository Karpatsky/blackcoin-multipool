using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BlackCoinMultipool.Core.Service;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;

namespace BlackCoinMultipool.UI.Android.Service
{
    public class CommonService : ICommonService
    {
        public string DonationAddressBlackcoin
        {
            get { return "BM4mL6tSo9EphkrnNBppzhjg5GsCXa9C2e"; }
        }
        public string DonationAddressBitcoin
        {
            get { return "13uua9VoFYPaRCXyuyepwpMQ1nu7JsAAT6"; }
        }   

        #region Translation resources needed in Core
        public string PopupOk
        {
            get { return GetString(Android.Resource.String.PopupOK); }
        }

        public string PopupYes
        {
            get { return GetString(Android.Resource.String.PopupYes); }
        }

        public string PopupNo
        {
            get { return GetString(Android.Resource.String.PopupNo); }
        }

        public string PopupFoundAddress
        {
            get { return GetString(Android.Resource.String.PopupFoundAddress); }
        }

        public string PopupIsThisCorrect
        {
            get { return GetString(Android.Resource.String.PopupIsThisCorrect); }
        }

        public string GettingStartedQRCodePopupText
        {
            get { return GetString(Android.Resource.String.GettingStartedQRCodePopupText); }
        }
        #endregion

        #region Private Methods
        private string GetString(int resourceId)
        {
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            return activity.GetString(resourceId);
        }
        #endregion


        public string StatisticsDay
        {
            get { return GetString(Android.Resource.String.StatisticsDay); }
        }

        public string StatisticsDays
        {
            get { return GetString(Android.Resource.String.StatisticsDays); }
        }

        public string BTC
        {
            get { return GetString(Android.Resource.String.BTC); }
        }

        public string StatisticsAgo
        {
            get { return GetString(Android.Resource.String.StatisticsAgo); }
        }

        public string BC
        {
            get { return GetString(Android.Resource.String.BC); }
        }
    }
}