using System;
using System.ComponentModel;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using EnvironmentTweaker.Configuration;
using Zenject;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class GameplaySetupViewController : IInitializable, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PluginConfig _config;

        public GameplaySetupViewController(PluginConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            if (_config.GameplaySetup)
            {
                GameplaySetup.instance.AddTab("EnvTweaker", "EnvironmentTweaker.UI.BSML.GameplaySetupSettingsView.bsml", this);
            }
        }

        public void Dispose()
        {
            if (GameplaySetup.instance != null)
            {
                GameplaySetup.instance.RemoveTab("EnvTweaker");
            }
        }
    }
}