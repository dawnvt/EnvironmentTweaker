using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using LightDimmer.Configuration;
using Zenject;

namespace LightDimmer.UI.ViewControllers
{
    [ViewDefinition("LightDimmer.UI.BSML.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\BSML\ModSettingsView.bsml")]
    public class ModSettingsViewController : BSMLAutomaticViewController, IInitializable, IDisposable, INotifyPropertyChanged
    {
        private PluginConfig _config;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public ModSettingsViewController(PluginConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("LightDimmer", "LightDimmer.UI.BSML.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
            BSMLSettings.instance.RemoveSettingsMenu(this);
        }

        [UIValue("dimming")]
        private bool Dimming
        {
            get => _config.Enabled; 
            set
            {
                _config.Enabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dimming)));
            }
        }
    }
}