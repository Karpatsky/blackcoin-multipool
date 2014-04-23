using Acr.MvvmCross.Plugins.BarCodeScanner;
using Acr.MvvmCross.Plugins.UserDialogs;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BlackCoinMultipool.Core.ViewModels
{
    public class GettingStartedViewModel : MvxViewModel
    {
        private ICommonService _commonService;
        private IUserDialogService _dialogService;
        private ISavedSettingsService _settingsService;

        private string _blackcoinAddress;
        public string BitcoinAddress
        {
            get { return _blackcoinAddress; }
            set { if (_blackcoinAddress == value) return; _blackcoinAddress = value; RaisePropertyChanged(() => BitcoinAddress); }
        }

        public GettingStartedViewModel()
        {
            _blackcoinAddress = string.Empty;
            _commonService = Mvx.Resolve<ICommonService>();
            _dialogService = Mvx.Resolve<IUserDialogService>();
            _settingsService = Mvx.Resolve<ISavedSettingsService>();

        }


        private MvxCommand scanCodeCommand;

        public MvxCommand ScanCodeCommand
        {
            get
            {
                scanCodeCommand = scanCodeCommand ?? new MvxCommand(DoScanCodeCommand);
                return scanCodeCommand;
            }
        }

        private async void DoScanCodeCommand()
        {
            var scanService = Mvx.Resolve<IBarCodeScanner>();
            var r = await scanService.Read(new BarCodeScannerOptions() { FlashlightText = "Turn on flashlight", CancelText = "Cancel" });

            var result = ExtractBitcoinAddress(r);

            _settingsService.BlackCoinAddress = result;

            if (!string.IsNullOrEmpty(result))
                ShowViewModel<StatisticsViewModel>();

        }

        private MvxCommand saveAddressCommand;

        public MvxCommand SaveAddressCommand
        {
            get
            {
                saveAddressCommand = saveAddressCommand ?? new MvxCommand(DoSaveAddressCommand);
                return saveAddressCommand;
            }
        }

        private void DoSaveAddressCommand()
        {
            _settingsService.BlackCoinAddress = _blackcoinAddress;

            if (!string.IsNullOrEmpty(_blackcoinAddress))
                ShowViewModel<StatisticsViewModel>();
        }

        private MvxCommand qrCodeHelpCommand;

        public MvxCommand QRCodeHelpCommand
        {
            get
            {
                qrCodeHelpCommand = qrCodeHelpCommand ?? new MvxCommand(DoQRCodeHelpCommand);
                return qrCodeHelpCommand;
            }
        }

        private async void DoQRCodeHelpCommand()
        {
            await _dialogService.AlertAsync(_commonService.GettingStartedQRCodePopupText, okText: _commonService.PopupOk);
        }



        #region Private Methods
        private string ExtractBitcoinAddress(BarCodeResult scannedCode)
        {
            if (scannedCode.Success == false)
                return string.Empty;
            else if (scannedCode.Format != BarCodeFormat.QR_CODE)
                return string.Empty;
            else
            {
                string code = scannedCode.Code;
                // first format:   bitcoin:15Jph2EW9AqCUWj529VE7byzfWxu3ir2t7
                // second format:  bitcoin:17xa9wyK6oq9NySL6ejtjyWVrPhPZs6TPu?label=auspex.clevermining.ios
                // third format:   bitcoin:1ALHfhe77VTzogkkBnQkTgH881VHhioczU?amount=0.01&label=auspex.clevermining.winphone&message=awesome

                if (code.Contains("?"))
                {
                    // second or third format, strip everything after ?
                    string[] codeParts = code.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                    if (codeParts.Length > 0)
                    {
                        code = codeParts[0];
                    }
                }
                if (code.StartsWith("bitcoin:"))
                {
                    // strip the bitcoin tag off
                    code = code.Substring(8);
                }

                return code;
            }

        }
        #endregion

    }
}
