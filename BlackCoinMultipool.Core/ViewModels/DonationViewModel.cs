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

        private string _donationAddress;
        public string DonationAddress
        {
            get { return _donationAddress; }
            set { if (_donationAddress == value) return; _donationAddress = value; RaisePropertyChanged(() => DonationAddress); }
        }


        public DonationViewModel()
        {
            _service = Mvx.Resolve<ICommonService>();
            DonationAddress = _service.DonationAddress;
        }

        private MvxCommand copyToClipboardCommand;

        public MvxCommand CopyToClipboardCommand
        {
            get
            {
                copyToClipboardCommand = copyToClipboardCommand ?? new MvxCommand(DoCopyToClipboardCommand);
                return copyToClipboardCommand;
            }
        }

        private void DoCopyToClipboardCommand()
        {
            var service = Mvx.Resolve<IClipboardService>();
            service.CopyToClipboard(DonationAddress);
        }

        
    }
}
