using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using IPALogger = IPA.Logging.Logger;
using LightDimmer.Configuration;
using Zenject;

namespace LightDimmer.UI.ViewControllers
{
    [ViewDefinition("LightDimmer.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    internal class ModSettingsViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        // Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Private fields
        private readonly PluginConfig _config;
        private readonly IPALogger _logger;
        
        public ModSettingsViewController(PluginConfig config, IPALogger logger)
        {
            _config = config;
            _logger = logger;
        }
        
        public void Initialize()
        {
            _logger.Info("Setting up settings menu..");
            BSMLSettings.instance.AddSettingsMenu("LightDimmer", "LightDimmer.UI.BSML.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
            _logger.Info("Disposing the settings menu");
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