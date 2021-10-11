using BeatSaberMarkupLanguage.Settings;
using IPA;
using IPA.Config.Stores;
using Config = IPA.Config.Config;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using LightDimmer.Configuration;
using LightDimmer.Installers;
using LightDimmer.UI.ViewControllers;
using SiraUtil.Tools;

namespace LightDimmer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private Config _config;
        private IPALogger _logger;

        [Init]
        public void Init(Zenjector zenjector, Config config, IPALogger logger)
        {
            
            _config = config.Generated<Config>();
            _logger = logger;
            
            zenjector.OnMenu<MenuInstaller>().WithParameters(_config, _logger);
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
