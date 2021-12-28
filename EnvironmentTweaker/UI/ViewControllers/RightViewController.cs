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
    [ViewDefinition("EnvironmentTweaker.UI.BSML.RightView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\BSML\RightView.bsml")]
    public class RightViewController : BSMLAutomaticViewController,
        IInitializable, IDisposable, INotifyPropertyChanged
    {
        // Public events and fields
        public event PropertyChangedEventHandler PropertyChanged;

        // Private fields
        private readonly SiraLog _log;
        private readonly PluginConfig _config;
        
        public RightViewController(SiraLog logger, PluginConfig config)
        {
            _log = logger;
            _config = config;
        }
        
        public void Initialize()
        { }

        public void Dispose()
        { }
    }
}