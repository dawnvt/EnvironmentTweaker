using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.ViewControllers;
using EnvironmentTweaker.Configuration;
using HMUI;
using Zenject;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class AdvancedSettingsViewController : BSMLAutomaticViewController, 
        IInitializable, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PluginConfig _config;

        public AdvancedSettingsViewController(PluginConfig config)
        {
            _config = config;
        }

        public void Initialize()
        { }

        public void Dispose()
        { }
    }
}