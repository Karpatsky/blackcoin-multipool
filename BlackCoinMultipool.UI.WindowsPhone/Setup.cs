using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using BlackCoinMultipool.Core.Service;
using BlackCoinMultipool.UI.WindowsPhone.Service;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCoinMultipool.UI.WindowsPhone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame)
            : base(rootFrame)
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
    }
}
