using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core;
using BlackCoinMultipool.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BlackCoinMultipool.Core.Model;

namespace BlackCoinMultipool.Core.ViewModels
{
    public class StatisticsViewModel : MvxViewModel
    {
        private readonly IBlackCoinMultipoolService _repository;
        private readonly ICommonService _common;
        private readonly ISavedSettingsService _savedSettings;
        public StatisticsViewModel(IBlackCoinMultipoolService repository, ICommonService common, ISavedSettingsService settings)
        {
            _repository = repository;
            _common = common;
            _savedSettings = settings;
            RefreshCommand.Execute();
        }

        private double _currentHashrateScrypt;
        public double CurrentHashrateScrypt
        {
            get { return _currentHashrateScrypt; }
            set { if (_currentHashrateScrypt == value) return; _currentHashrateScrypt = value; RaisePropertyChanged(() => CurrentHashrateScrypt); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { if (_address == value) return; _address = value; RaisePropertyChanged(() => Address); }
        }

        private double _currentHashrateSha256;
        public double CurrentHashrateSha256
        {
            get { return _currentHashrateSha256; }
            set { if (_currentHashrateSha256 == value) return; _currentHashrateSha256 = value; RaisePropertyChanged(() => CurrentHashrateSha256); }
        }

        private long _currentSharesScrypt;
        public long CurrentSharesScrypt
        {
            get { return _currentSharesScrypt; }
            set { if (_currentSharesScrypt == value) return; _currentSharesScrypt = value; RaisePropertyChanged(() => CurrentSharesScrypt); }
        }

        private long _currentSharesSha256;
        public long CurrentSharesSha256
        {
            get { return _currentSharesSha256; }
            set { if (_currentSharesSha256 == value) return; _currentSharesSha256 = value; RaisePropertyChanged(() => CurrentSharesSha256); }
        }

        private string _latestPayoutScrypt;
        public string LatestPayoutScrypt
        {
            get { return _latestPayoutScrypt; }
            set { if (_latestPayoutScrypt == value) return; _latestPayoutScrypt = value; RaisePropertyChanged(() => LatestPayoutScrypt); }
        }

        private string _latestPayoutSha256;
        public string LatestPayoutSha256
        {
            get { return _latestPayoutSha256; }
            set { if (_latestPayoutSha256 == value) return; _latestPayoutSha256 = value; RaisePropertyChanged(() => LatestPayoutSha256); }
        }

        private ObservableCollection<Shift> _shifts;
        public ObservableCollection<Shift> Shifts
        {
            get { return _shifts; }
            set { if (_shifts == value) return; _shifts = value; RaisePropertyChanged(() => Shifts); }
        }


        private MvxCommand refreshCommand;

        public MvxCommand RefreshCommand
        {
            get
            {
                refreshCommand = refreshCommand ?? new MvxCommand(DoRefreshCommand);
                return refreshCommand;
            }
        }

        private async void DoRefreshCommand()
        {
            var stats = await _repository.GetStatistics(_savedSettings.BlackCoinAddress);

            Address = stats.Address;
            CurrentHashrateScrypt = stats.HashRateScrypt;
            CurrentHashrateSha256 = stats.HashRateSHA256;
            CurrentSharesScrypt = stats.CurrentSharesScrypt;
            CurrentSharesSha256 = stats.CurrentSharesSHA256;
            LatestPayoutScrypt = string.Format("{0} {1}", stats.LatestPayoutScrypt, _common.BC);
            LatestPayoutSha256 = string.Format("{0} {1}", stats.LatestPayoutSHA256, _common.BC);
            if (stats.Shifts != null)
                Shifts = new ObservableCollection<Shift>(stats.Shifts);
        }

        private MvxCommand donateCommand;

        public MvxCommand DonateCommand
        {
            get
            {
                donateCommand = donateCommand ?? new MvxCommand(DoDonateCommand);
                return donateCommand;
            }
        }

        private void DoDonateCommand()
        {
            ShowViewModel<DonationViewModel>();
        }

        private MvxCommand settingsCommand;

        public MvxCommand SettingsCommand
        {
            get
            {
                settingsCommand = settingsCommand ?? new MvxCommand(DoSettingsCommand);
                return settingsCommand;
            }
        }

        private void DoSettingsCommand()
        {
            ShowViewModel<SettingsViewModel>();
        }

        private MvxCommand aboutCommand;

        public MvxCommand AboutCommand
        {
            get
            {
                aboutCommand = aboutCommand ?? new MvxCommand(DoAboutCommand);
                return aboutCommand;
            }
        }

        private void DoAboutCommand()
        {
            ShowViewModel<AboutViewModel>();
        }           
    }
}
