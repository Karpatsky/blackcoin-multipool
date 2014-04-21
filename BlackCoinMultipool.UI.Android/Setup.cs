using Android.Content;
using BlackCoinMultipool.Core.Service;
using BlackCoinMultipool.UI.Android.Service;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

namespace BlackCoinMultipool.UI.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<ICommonService, CommonService>();
            Mvx.RegisterType<IClipboardService, ClipboardService>();

            return new Core.BlackCoinMultipoolApplication();
        }
        protected override IMvxNavigationSerializer CreateNavigationSerializer()
        {
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
            return new MvxJsonNavigationSerializer();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }


    }
}