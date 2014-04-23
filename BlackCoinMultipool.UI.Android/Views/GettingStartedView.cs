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

//using DK.Ostebaronen.Droid.ViewPagerIndicator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using DK.Ostebaronen.Droid.ViewPagerIndicator;

namespace BlackCoinMultipool.UI.Android.Views
{
    [Activity(Label = "@string/PageGettingStarted", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class GettingStartedView : MvxFragmentActivity
    {
        private ViewPager _viewPager;
        private TabPageIndicator _pageIndicator;
        private FragmentTabsAdapter _tabAdapter;
        private LinearLayout _layoutBase;

        public GettingStartedViewModel GettingStartedViewModel
        {
            get { return (GettingStartedViewModel)base.ViewModel; }
        }

        #region View lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GettingStartedView);

            ActionBar.Title = GetString(Resource.String.PageGettingStarted);
            ActionBar.SetHomeButtonEnabled(false);
            ActionBar.SetDisplayHomeAsUpEnabled(false);
            ActionBar.Show();

            _viewPager = FindViewById<ViewPager>(Resource.Id.page_gettingstarted_pager);
            _pageIndicator = FindViewById<TabPageIndicator>(Resource.Id.page_gettingstarted_indicator);
            _layoutBase = FindViewById<LinearLayout>(Resource.Id.layout_gettingstarted);

            var fragments = new List<FragmentTabsAdapter.FragmentInfo>
              {
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(GettingStartedAutomaticFragment),
                  Title = GetString(Resource.String.GettingStartedAutomatic),
                  ViewModel = this.ViewModel
                },
                new FragmentTabsAdapter.FragmentInfo
                {
                  FragmentType = typeof(GettingStartedManualFragment),
                  Title = GetString(Resource.String.GettingStartedManual),
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

    }
}