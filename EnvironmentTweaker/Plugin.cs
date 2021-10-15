using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using EnvironmentTweaker.Configuration;
using EnvironmentTweaker.Installers;
using SiraUtil.Zenject;

namespace EnvironmentTweaker
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
