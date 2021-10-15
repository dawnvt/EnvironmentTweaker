using EnvironmentTweaker.Configuration;
using EnvironmentTweaker.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace EnvironmentTweaker
{
    [Plugin(RuntimeOptions.DynamicInit)]
    internal class Plugin
    {
        internal static IPALogger Log { get; private set; }
        internal static PluginConfig Config { get; private set; }

        [Init]
        public void Init(IPALogger logger, PluginMetadata metadata, Config config, Zenjector zenjector)
        {
            Log = logger;
            Config = config.Generated<PluginConfig>();

            zenjector.On<PCAppInit>().Pseudo(container =>
            {
                container.BindLoggerAsSiraLogger(logger);
                container.BindInstance(new UBinder<Plugin, PluginMetadata>(metadata));
                container.BindInstance(Config);
            });
            zenjector.OnMenu<ETMenuInstaller>();
            zenjector.OnGame<ETGameInstaller>()
                .ShortCircuitForMultiplayer()
                .ShortCircuitForTutorial();
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        { }
    }
}
