using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using IPA.Config;
using IPA.Config.Data;
using LightDimmer.Configuration;
using Zenject;

namespace LightDimmer.UI.ViewControllers
{
    [ViewDefinition("LightDimmer.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class ModSettingsViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        //Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Private injection fields
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
    }
}