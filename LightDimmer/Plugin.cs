using Hive.Versioning;
using IPA;
using SiraUtil.Zenject;
using Zenject;
using IPALogger = IPA.Logging.Logger;
using IPA.Config.Stores;
using IPA.Loader;
using JetBrains.Annotations;
using ScoreRequirement.Configuration;
using ScoreRequirement.Installers;
using Config = IPA.Config.Config;

namespace ScoreRequirement
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
