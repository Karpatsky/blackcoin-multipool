using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core.Service;
using BlackCoinMultipool.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core
{
    public class BlackCoinMultipoolAppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly ISavedSettingsService _service;
        public BlackCoinMultipoolAppStart(ISavedSettingsService service)
        {
            _service = service;

        }

        public void Start(object hint = null)
        {
            // if the blackcoinaddress is stored in the settings, bypass the getting-started page (one can always return to that later on)
            if (string.IsNullOrEmpty(_service.BlackCoinAddress))
            {
                ShowViewModel<GettingStartedViewModel>();
            } 
            else
            {
                ShowViewModel<StatisticsViewModel>();
            }
        }
    }
}
