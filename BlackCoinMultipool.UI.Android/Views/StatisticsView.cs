using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Views;

using BlackCoinMultipool.UI.Android.Adapters;
using BlackCoinMultipool.UI.Android.Views.Fragments;
using BlackCoinMultipool.Core.ViewModels;

using DK.Ostebaronen.Droid.ViewPagerIndicator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackCoinMultipool.UI.Android.Views
{
    [Activity(Label = "@string/ApplicationTitle", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class StatisticsView : MvxFragmentActivity
    {
        private ViewPager _viewPager;
        private TabPageIndicator _pageIndicator;
        private FragmentTabsAdapter _tabAdapter;
        private LinearLayout _layoutBase;

        public StatisticsViewModel StatisticsViewModel
        {
            get { return (StatisticsViewModel)base.ViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StatisticsView);

            ActionBar.Title = GetString(Resource.String.ApplicationTitle);
            ActionBar.SetHomeButtonEnabled(false);
            ActionBar.SetDisplayHomeAsUpEnabled(false); 
            ActionBar.Show();

            _viewPager = FindViewById<ViewPager>(Resource.Id.page_stats_pager);
            _pageIndicator = FindViewById<TabPageIndicator>(Resource.Id.page_stats_indicator);
            _layoutBase = FindViewById<LinearLayout>(Resource.Id.layout_statistics);

            var fragments = new List<FragmentTabsAdapter.FragmentInfo>
              {
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(StatisticsHashrateFragment),
                  Title = GetString(Resource.String.PageStatsCurrentHashrateScrypt),
                  ViewModel = this.ViewModel
                },
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(StatisticsSha256HashrateFragment),
                  Title = GetString(Resource.String.PageStatsCurrentHashrateSha256),
                  ViewModel = this.ViewModel
                },
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(StatisticsStatisticsFragment),
                  Title = GetString(Resource.String.PageStatsStats),
                  ViewModel = this.ViewModel
                },
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(StatisticsShiftsFragment),
                  Title = GetString(Resource.String.PageStatsShifts),
                  ViewModel = this.ViewModel
                }
              };

            if (_viewPager != null && _pageIndicator != null)
            {
                _tabAdapter = new FragmentTabsAdapter(this, SupportFragmentManager, fragments);
                _viewPager.Adapter = _tabAdapter;
                _viewPager.OffscreenPageLimit = 4;
                _pageIndicator.SetViewPager(_viewPager);
                _pageIndicator.CurrentItem = 0;
            }
            //else if (_layoutBase != null)
            //{
            //    _layoutBase.AddView(LayoutInflater.Inflate(Resource.Layout.GettingStartedAutomaticFragment, null));
            //    _layoutBase.AddView(LayoutInflater.Inflate(Resource.Layout.GettingStartedManualFragment, null));
            //}

        }

        #region Menu handling
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // Inflate the menu items for use in the action bar
            MenuInflater.Inflate(Resource.Menu.statistics_activity_actions, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // Handle presses on the action bar items
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    Finish();
                    return true;
                case Resource.Id.action_statistics_refresh:
                    StatisticsViewModel.RefreshCommand.Execute();
                    return true;
                case Resource.Id.action_statistics_donate:
                    StatisticsViewModel.DonateCommand.Execute();
                    return true;
                case Resource.Id.action_statistics_settings:
                    StatisticsViewModel.SettingsCommand.Execute();
                    return true;
                case Resource.Id.action_statistics_about:
                    StatisticsViewModel.AboutCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
        #endregion
    }
}