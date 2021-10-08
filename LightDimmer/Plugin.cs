using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using LightDimmer.Configuration;
using LightDimmer.Installers;
using LightDimmer.UI.ViewControllers;
using IPALogger = IPA.Logging.Logger;

namespace LightDimmer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private PluginConfig _config;
        private IPALogger _logger;

        [Init]
        public void Init(Config config, Zenjector zenjector, IPALogger logger)
        {
            _config = config.Generated<PluginConfig>();
            _logger = logger;
            
            zenjector.OnMenu<MenuInstaller>().WithParameters(_config, _logger);
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
