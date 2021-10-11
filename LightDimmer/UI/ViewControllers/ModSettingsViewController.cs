using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using IPA.Config.Data;
using JetBrains.Annotations;
using LightDimmer.Configuration;
using Zenject;

namespace LightDimmer.UI.ViewControllers
{
    [ViewDefinition("LightDimmer.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class ModSettingsViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        // Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Private fields
        private readonly PluginConfig _config;
        
        public ModSettingsViewController(PluginConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("LightDimmer", "LightDimmer.UI.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
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

        [UIValue("lightingIntensity")]
        internal float LightIntensity
        {
            get => _config.Intensity;
            set
            {
                _config.Intensity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightIntensity)));
            }
        }
    }
}