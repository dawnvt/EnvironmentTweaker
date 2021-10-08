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
            Container.BindInstance(_logger);
            Container.BindInterfacesAndSelfTo<ModSettingsViewController>().AsSingle();
        }
    }

    
}