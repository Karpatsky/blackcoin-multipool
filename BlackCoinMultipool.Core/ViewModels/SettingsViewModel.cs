using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        private readonly ISavedSettingsService _service;

        private string _blackCoinAddress;
        public string BlackCoinAddress
        {
            get { return _blackCoinAddress; }
            set { if (_blackCoinAddress == value) return; _blackCoinAddress = value; RaisePropertyChanged(() => BlackCoinAddress); }
        }


        public SettingsViewModel()
        {
            _service = Mvx.Resolve<ISavedSettingsService>();
            BlackCoinAddress = _service.BlackCoinAddress;
        }

        private MvxCommand clearAddressCommand;

        public MvxCommand ClearAddressCommand
        {
            get
            {
                clearAddressCommand = clearAddressCommand ?? new MvxCommand(DoClearAddressCommand);
                return clearAddressCommand;
            }
        }

        private void DoClearAddressCommand()
        {
            _service.BlackCoinAddress = string.Empty;
            ShowViewModel<GettingStartedViewModel>();
        }

        
    }
}
