using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using IPALogger = IPA.Logging.Logger;
using EnvironmentTweaker.Configuration;
using Zenject;
using SiraUtil.Tools;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    internal class ModSettingsViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        // Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;

        // Private fields
        private readonly SiraLog _log;
        private readonly PluginConfig _config;
        
        public ModSettingsViewController(SiraLog logger, PluginConfig config)
        {
            _log = logger;
            _config = config;
        }
        
        public void Initialize()
        {
            _log.Info("Setting up settings menu..");
            BSMLSettings.instance.AddSettingsMenu("EnvironmentTweaker", "EnvironmentTweaker.UI.BSML.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
            _log.Info("Disposing the settings menu");
            BSMLSettings.instance.RemoveSettingsMenu(this);
        }

        [UIValue("dimming")]
        internal bool Dimming
        {
            get => _config.Enabled;
            set
            {
                _config.Enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dimming)));
            }
        }

        [UIValue("lightIntensity")]
        internal float LightIntensity
        {
            get => _config.Intensity;
            set
            {
                _config.Intensity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightIntensity)));
            }
        }

        [UIValue("intensityText")]
        internal string IntensityString => $"How intense you want the lights to be \n Default is 1";
    }
}