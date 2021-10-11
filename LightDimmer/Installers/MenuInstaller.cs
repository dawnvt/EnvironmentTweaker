using IPA.Config;
using LightDimmer.Configuration;
using LightDimmer.UI.ViewControllers;
using SiraUtil;
using SiraUtil.Tools;
using Zenject;
using IPALogger = IPA.Logging.Logger;

namespace LightDimmer.Installers
{
    public class MenuInstaller : Installer
    {
        private readonly Config _config;
        private readonly IPALogger _logger;
        
        public MenuInstaller(Config config, IPALogger logger)
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