using EnvironmentTweaker.UI.ViewControllers;
using Zenject;

namespace EnvironmentTweaker.Installers
{
    internal class ETMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ModSettingsViewController>().AsSingle();
        }
    }
}