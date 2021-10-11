using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using LightDimmer.Configuration;
using LightDimmer.Installers;
using SiraUtil.Zenject;

namespace LightDimmer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public void Init(Config config, Logger logger, Zenjector zenjector)
        {
            zenjector.OnMenu<MenuInstaller>().WithParameters(config.Generated<PluginConfig>(), logger);
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
