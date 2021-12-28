using EnvironmentTweaker.Configuration;
using EnvironmentTweaker.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil;
using SiraUtil.Tools;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace EnvironmentTweaker
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    internal class Plugin
    {
        [Init]
        public void Init(IPALogger logger, PluginMetadata metadata, Config config, Zenjector zenjector)
        {
            zenjector.UseLogger(logger);
            
            zenjector.Install<AppInstaller>(Location.App, config.Generated<PluginConfig>());
            zenjector.Install<ETMenuInstaller>(Location.Menu);
            zenjector.Install<ETGameInstaller>(Location.GameCore);
        }
    }
}
