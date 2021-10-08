using BeatSaberMarkupLanguage.Settings;
using IPA;
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
        private PluginConfig _config;
        private IPALogger _logger;

        [Init]
        public void Init(Zenjector zenjector, PluginConfig config, IPALogger logger)
        {
            _config = config;
            _logger = logger;
            
            zenjector.OnMenu<MenuInstaller>().WithParameters(_config, _logger);
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
