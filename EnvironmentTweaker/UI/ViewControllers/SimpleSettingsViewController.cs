using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using IPALogger = IPA.Logging.Logger;
using EnvironmentTweaker.Configuration;
using SiraUtil.Logging;
using Zenject;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class SimpleSettingsViewController : BSMLAutomaticViewController,
        IInitializable, IDisposable, INotifyPropertyChanged
    {
        // Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;

        // Private fields
        private readonly SiraLog _log;
        private readonly PluginConfig _config;
        
        public SimpleSettingsViewController(SiraLog logger, PluginConfig config)
        {
            _log = logger;
            _config = config;
        }
        
        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("EnvironmentTweaker", "EnvironmentTweaker.UI.BSML.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
            if (BSMLSettings.instance != null)
            {
                BSMLSettings.instance.RemoveSettingsMenu(this);
                _log.Logger?.Info("Disposed of Mod Settings UI..");
            }
            
        }

        [UIValue("gameplaySetup")]
        internal bool GameplaySetupBool
        {
            get => _config.GameplaySetup;
            set
            {
                _config.GameplaySetup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameplaySetupBool)));
            }
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
        
        [UIValue("gameplaysetupText")]
        internal string GameplaySetupString => $"Install UI to the \n gameplay setup UI";

        [UIValue("isSimple")]
        internal bool IsSimple
        {
            get => listChoice == "Simple";
            set
            {
                IsSimple = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(IsSimple)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAdvanced)));
            }
        }
        
        [UIValue("isAdvanced")]
        internal bool IsAdvanced => !IsSimple;

        [UIValue("list-options")]
        private List<object> options = new object[] { "Simple", "Advanced" }.ToList();

        [UIValue("list-choice")]
        private string listChoice = "Simple";
    }
}