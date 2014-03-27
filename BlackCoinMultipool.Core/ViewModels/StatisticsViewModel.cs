using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core;
using BlackCoinMultipool.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private string _totalProfit;
        public string TotalProfit
        {
            get { return _totalProfit; }
            set { if (_totalProfit == value) return; _totalProfit = value; RaisePropertyChanged(() => TotalProfit); }
        }

        private double _hashRate;
        public double HashRate
        {
            get { return _hashRate; }
            set { if (_hashRate == value) return; _hashRate = value; RaisePropertyChanged(() => HashRate); }
        }

        private string _last24Hours;
        public string Last24Hours
        {
            get { return _last24Hours; }
            set { if (_last24Hours == value) return; _last24Hours = value; RaisePropertyChanged(() => Last24Hours); }
        }

        private string _joined;
        public string Joined
        {
            get { return _joined; }
            set { if (_joined == value) return; _joined = value; RaisePropertyChanged(() => Joined); }
        }

        private string _lastPayout;
        public string LastPayout
        {
            get { return _lastPayout; }
            set { if (_lastPayout == value) return; _lastPayout = value; RaisePropertyChanged(() => LastPayout); }
        }

        private string _miningDays;
        public string MiningDays
        {
            get { return _miningDays; }
            set { if (_miningDays == value) return; _miningDays = value; RaisePropertyChanged(() => MiningDays); }
        }

        private string _immature;
        public string Immature
        {
            get { return _immature; }
            set { if (_immature == value) return; _immature = value; RaisePropertyChanged(() => Immature); }
        }

        private string _unexchanged;
        public string Unexchanged
        {
            get { return _unexchanged; }
            set { if (_unexchanged == value) return; _unexchanged = value; RaisePropertyChanged(() => Unexchanged); }
        }

        private string _readyForPayout;
        public string ReadyForPayout
        {
            get { return _readyForPayout; }
            set { if (_readyForPayout == value) return; _readyForPayout = value; RaisePropertyChanged(() => ReadyForPayout); }
        }

        private string _totalExpected;
        public string TotalExpected
        {
            get { return _totalExpected; }
            set { if (_totalExpected == value) return; _totalExpected = value; RaisePropertyChanged(() => TotalExpected); }
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
            TotalProfit = string.Format("{0} {1}",stats.TotalProfit, _common.BTC);
            Last24Hours = string.Format("{0} {1}",stats.Last24hProfit, _common.BTC);
            var dayOrDays = stats.LastPayout == 1 ? _common.StatisticsDay : _common.StatisticsDays;
            LastPayout = string.Format("{0} {1} {2}",stats.LastPayout, dayOrDays, _common.StatisticsAgo);
            dayOrDays = stats.MiningDays == 1 ? _common.StatisticsDay : _common.StatisticsDays;
            MiningDays = string.Format("{0} {1}", stats.MiningDays, dayOrDays);
            Immature = string.Format("{0} {1}", stats.Immature, _common.BTC);
            Unexchanged = string.Format("{0} {1}", stats.Unexchanged, _common.BTC);
            ReadyForPayout = string.Format("{0} {1}", stats.ReadyForPayout, _common.BTC);
            TotalExpected = string.Format("{0} {1}", stats.TotalExpected, _common.BTC);

            Joined = stats.Joined.ToString();
            HashRate = HashRate + stats.HashRate;
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
