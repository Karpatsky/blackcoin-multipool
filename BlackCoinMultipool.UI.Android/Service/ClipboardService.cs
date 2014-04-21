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
using BlackCoinMultipool.Core.Service;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;

namespace BlackCoinMultipool.UI.Android.Service
{
    public class ClipboardService : IClipboardService
    {
        public void CopyToClipboard(object item)
        {
            // only copy strings to clipboard for now
            var text = item as string;
            var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
            var clipBoardManager = (ClipboardManager)activity.GetSystemService(Context.ClipboardService);            
            ClipData clip = ClipData.NewPlainText("bitcoin", text);
            clipBoardManager.PrimaryClip = clip;
        }
    }
}