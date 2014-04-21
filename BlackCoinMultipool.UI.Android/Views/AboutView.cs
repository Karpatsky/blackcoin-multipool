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

namespace BlackCoinMultipool.UI.Android.Views
{
    [Activity(Label = "@string/PageAbout", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@drawable/icon")]
    public class AboutView : MvxActivity
    {
        public AboutViewModel AboutViewModel
        {
            get { return (AboutViewModel)base.ViewModel; }
        }

        #region View lifecycle
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AboutView);

            ActionBar.Title = GetString(Resource.String.PageAbout);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);  // < icon erbij
            ActionBar.Show();
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