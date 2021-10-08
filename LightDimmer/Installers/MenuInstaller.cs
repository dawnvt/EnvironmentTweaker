using LightDimmer.Configuration;
using LightDimmer.UI.ViewControllers;
using IPALogger = IPA.Logging.Logger;
using SiraUtil;
using Zenject;

namespace LightDimmer.Installers
{
    public class MenuInstaller : Installer
    {
        private readonly PluginConfig _config;
        private readonly IPALogger _logger;

        public MenuInstaller(PluginConfig config, IPALogger logger)
        {
            _config = config;
            _logger = logger;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindLoggerAsSiraLogger(_logger);
            Container.Bind<ModSettingsViewController>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}