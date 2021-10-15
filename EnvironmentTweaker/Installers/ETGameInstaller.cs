using Zenject;

namespace EnvironmentTweaker.Installers
{
    internal class ETGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LightManager>().AsSingle();
        }
    }
}