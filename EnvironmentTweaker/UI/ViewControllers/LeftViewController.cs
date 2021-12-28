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
    [ViewDefinition("EnvironmentTweaker.UI.BSML.LeftView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\BSML\LeftView.bsml")]
    public class LeftViewController : BSMLAutomaticViewController, 
        IInitializable, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PluginConfig _config;

        public LeftViewController(PluginConfig config)
        {
            _config = config;
        }

        public void Initialize()
        { }

        public void Dispose()
        { }
    }
}