using LightDimmer.Configuration;
using LightDimmer.UI.ViewControllers;
using Zenject;

namespace LightDimmer.Installers
{
    public class MenuInstaller : Installer
    {
        private readonly PluginConfig _config;
        
        public MenuInstaller(PluginConfig config)
        {
            _config = config;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindInterfacesAndSelfTo<ModSettingsViewController>().AsSingle();
        }
    }
}