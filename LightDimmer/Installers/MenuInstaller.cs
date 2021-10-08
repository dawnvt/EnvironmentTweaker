using IPA.Logging;
using LightDimmer.Configuration;
using LightDimmer.UI.ViewControllers;
using SiraUtil;
using SiraUtil.Tools;
using Zenject;

namespace LightDimmer.Installers
{
    public class MenuInstaller : Installer
    {
        private readonly PluginConfig _config;
        private readonly Logger _logger;
        
        public MenuInstaller(PluginConfig config, Logger logger)
        {
            _config = config;
            _logger = logger;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindLoggerAsSiraLogger(_logger);
            Container.BindInterfacesAndSelfTo<ModSettingsViewController>().AsSingle();
        }
    }
}