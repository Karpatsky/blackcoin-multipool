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
    public class DonationViewModel : MvxViewModel
    {
        private ICommonService _service;

        public DonationViewModel()
        {
            _service = Mvx.Resolve<ICommonService>();
            DonationAddressBlackcoin = _service.DonationAddressBlackcoin;
            DonationAddressBitcoin = _service.DonationAddressBitcoin;
        }

        #region Blackcoin

        private string _donationAddressBlackcoin;
        public string DonationAddressBlackcoin
        {
            get { return _donationAddressBlackcoin; }
            set { if (_donationAddressBlackcoin == value) return; _donationAddressBlackcoin = value; RaisePropertyChanged(() => DonationAddressBlackcoin); }
        }

        private MvxCommand copyToClipboardBlackcoinCommand;

        public MvxCommand CopyToClipboardBlackcoinCommand
        {
            get
            {
                copyToClipboardBlackcoinCommand = copyToClipboardBlackcoinCommand ?? new MvxCommand(DoCopyToClipboardBlackcoinCommand);
                return copyToClipboardBlackcoinCommand;
            }
        }

        private void DoCopyToClipboardBlackcoinCommand()
        {
            var service = Mvx.Resolve<IClipboardService>();
            service.CopyToClipboard(DonationAddressBlackcoin);
        }

        #endregion

        #region Bitcoin

        private string _donationAddressBitcoin;
        public string DonationAddressBitcoin
        {
            get { return _donationAddressBitcoin; }
            set { if (_donationAddressBitcoin == value) return; _donationAddressBitcoin = value; RaisePropertyChanged(() => DonationAddressBitcoin); }
        }

        private MvxCommand copyToClipboardBitcoinCommand;

        public MvxCommand CopyToClipboardBitcoinCommand
        {
            get
            {
                copyToClipboardBitcoinCommand = copyToClipboardBitcoinCommand ?? new MvxCommand(DoCopyToClipboardBitcoinCommand);
                return copyToClipboardBitcoinCommand;
            }
        }

        private void DoCopyToClipboardBitcoinCommand()
        {
            var service = Mvx.Resolve<IClipboardService>();
            service.CopyToClipboard(DonationAddressBitcoin);
        }

        #endregion


    }
}
