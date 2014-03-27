using Acr.MvvmCross.Plugins.Settings;
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.Service
{
    public class SavedSettingsService : ISavedSettingsService
    {
        private readonly ISettingsService _settingsService;

        private string _blackCoinAddress;
        public string BlackCoinAddress
        {
            get
            {
                return _blackCoinAddress;
            }
            set
            {
                _settingsService.Set("BlackCoinAddress", value);
                _blackCoinAddress = value;
            }
        }

        public SavedSettingsService()
        {
            _settingsService = Mvx.Resolve<ISettingsService>();
            _blackCoinAddress = _settingsService.Get("BlackCoinAddress");
        }
    }
}
