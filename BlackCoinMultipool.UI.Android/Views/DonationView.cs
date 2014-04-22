using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Cirrious.MvvmCross.Droid.Views;
using BlackCoinMultipool.Core.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.View;
using DK.Ostebaronen.Droid.ViewPagerIndicator;
using BlackCoinMultipool.UI.Android.Adapters;
using BlackCoinMultipool.UI.Android.Views.Fragments;
using Cirrious.MvvmCross.Droid.Fragging;

namespace BlackCoinMultipool.UI.Android.Views
{
    [Activity(Label = "@string/PageDonate", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class DonationView : MvxFragmentActivity
    {
        private ViewPager _viewPager;
        private TabPageIndicator _pageIndicator;
        private FragmentTabsAdapter _tabAdapter;
        private LinearLayout _layoutBase;

        public DonationViewModel DonationViewModel
        {
            get { return (DonationViewModel)base.ViewModel; }
        }

        #region View lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DonationView);

            ActionBar.Title = GetString(Resource.String.PageDonate);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);  // < icon erbij
            ActionBar.Show();

            _viewPager = FindViewById<ViewPager>(Resource.Id.page_donate_pager);
            _pageIndicator = FindViewById<TabPageIndicator>(Resource.Id.page_donate_indicator);
            _layoutBase = FindViewById<LinearLayout>(Resource.Id.layout_donation);

            var fragments = new List<FragmentTabsAdapter.FragmentInfo>
              {
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(DonateBlackcoinFragment),
                  Title = GetString(Resource.String.DonateTabBlackcoin),
                  ViewModel = this.ViewModel
                },
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(DonateBitcoinFragment),
                  Title = GetString(Resource.String.DonateTabBitcoin),
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
            else if (_layoutBase != null)
            {
                _layoutBase.AddView(LayoutInflater.Inflate(Resource.Layout.GettingStartedAutomaticFragment, null));
                _layoutBase.AddView(LayoutInflater.Inflate(Resource.Layout.GettingStartedManualFragment, null));
            }
        }
        #endregion

        #region Menu handling
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // Handle presses on the action bar items
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    // do donate
                    Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
        #endregion
    }
}