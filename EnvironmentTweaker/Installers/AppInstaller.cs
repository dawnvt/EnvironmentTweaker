using EnvironmentTweaker.Configuration;
using Zenject;

namespace EnvironmentTweaker.Installers
{
    public class AppInstaller : Installer
    {
        private readonly PluginConfig _config;
        
        public AppInstaller(PluginConfig config)
        {
            _config = config;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(_config);
        }
    }
}