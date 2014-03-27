using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cirrious.MvvmCross.WindowsPhone.Views;
using BlackCoinMultipool.Core.ViewModels;
using BlackCoinMultipool.UI.WindowsPhone.Resources;

namespace BlackCoinMultipool.UI.WindowsPhone.Views
{
    public partial class StatisticsView : MvxPhonePage
    {
        public new StatisticsViewModel ViewModel
        {
            get { return (StatisticsViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public StatisticsView()
        {
            InitializeComponent();

            SetupApplicationBar();
        }


        private void SetupApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton buttonRefresh = new ApplicationBarIconButton();
            buttonRefresh.IconUri = new Uri("/Assets/Icons/appbar.refresh.png", UriKind.Relative);
            buttonRefresh.Text = AppResources.ResourceManager.GetString("MenuRefresh", AppResources.Culture);
            buttonRefresh.Click += new EventHandler((s,e) => ViewModel.RefreshCommand.Execute());
            ApplicationBar.Buttons.Add(buttonRefresh);

            ApplicationBarIconButton buttonDonate = new ApplicationBarIconButton();
            buttonDonate.IconUri = new Uri("/Assets/Icons/appbar.donate.png", UriKind.Relative);
            buttonDonate.Text = AppResources.ResourceManager.GetString("MenuDonate", AppResources.Culture);
            buttonDonate.Click += new EventHandler((s,e) => ViewModel.DonateCommand.Execute());
            ApplicationBar.Buttons.Add(buttonDonate);

            ApplicationBarMenuItem menuItemSettings = new ApplicationBarMenuItem();
            menuItemSettings.Text = AppResources.ResourceManager.GetString("MenuSettings", AppResources.Culture);
            menuItemSettings.Click += new EventHandler((s,e) => ViewModel.SettingsCommand.Execute());
            ApplicationBar.MenuItems.Add(menuItemSettings);

            ApplicationBarMenuItem menuItemAbout = new ApplicationBarMenuItem();
            menuItemAbout.Text = AppResources.ResourceManager.GetString("MenuAbout", AppResources.Culture);
            menuItemAbout.Click += new EventHandler((s,e) => ViewModel.AboutCommand.Execute());
            ApplicationBar.MenuItems.Add(menuItemAbout);
        }

    }
}