using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;


namespace BlackCoinMultipool.UI.Android.Views.Fragments
{
    public class DonateBlackcoinFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                          Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.DonateBlackcoinFragment, null);
        }
    }
}