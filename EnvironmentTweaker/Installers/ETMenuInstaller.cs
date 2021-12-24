using EnvironmentTweaker.UI;
using EnvironmentTweaker.UI.ViewControllers;
using Zenject;

namespace EnvironmentTweaker.Installers
{
    internal class ETMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuButtonUI>().AsSingle();
            Container.BindInterfacesAndSelfTo<ModSettingsViewController>().AsSingle();
        }
    }
}