using Zenject;

namespace EnvironmentTweaker.Installers
{
    internal class ETGameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LightManager>().AsSingle();
        }
    }
}