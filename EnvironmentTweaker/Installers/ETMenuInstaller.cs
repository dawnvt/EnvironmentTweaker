using EnvironmentTweaker.UI;
using EnvironmentTweaker.UI.FlowCoordinators;
using EnvironmentTweaker.UI.ViewControllers;
using Zenject;

namespace EnvironmentTweaker.Installers
{
    internal class ETMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuButtonUI>().AsSingle();
            Container.BindInterfacesAndSelfTo<SimpleSettingsViewController>()
                .FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<AdvancedSettingsViewController>()
                .FromNewComponentAsViewController().AsSingle();
            Container.Bind<ETSettingsFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();

            Container.BindInterfacesTo<LightManager>().AsSingle();
        }
    }
}