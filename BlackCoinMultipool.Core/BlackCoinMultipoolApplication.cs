using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using BlackCoinMultipool.Core.Service;
using BlackCoinMultipool.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackCoinMultipool.Core
{
    public class BlackCoinMultipoolApplication : MvxApplication
    {
        public BlackCoinMultipoolApplication()
        {
            Mvx.RegisterType<ISavedSettingsService, SavedSettingsService>();
            Mvx.RegisterType<IBlackCoinMultipoolService, BlackCoinMultipoolService>();
            Mvx.RegisterSingleton<IMvxAppStart>(new BlackCoinMultipoolAppStart(Mvx.Resolve<ISavedSettingsService>()));
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);
            pluginManager.EnsurePluginLoaded<Acr.MvvmCross.Plugins.BarCodeScanner.PluginLoader>();
            pluginManager.EnsurePluginLoaded<Acr.MvvmCross.Plugins.UserDialogs.PluginLoader>();
            pluginManager.EnsurePluginLoaded<Acr.MvvmCross.Plugins.Settings.PluginLoader>();
        }
    }
}
