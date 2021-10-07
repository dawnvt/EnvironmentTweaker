using IPA;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using IPA.Loader;
using LightDimmer.Configuration;
using Config = IPA.Config.Config;

namespace LightDimmer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private PluginConfig _config;

        [Init]
        public void Init(Zenjector zenjector, Config config, IPALogger logger, PluginMetadata pluginMetadata)
        {
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
