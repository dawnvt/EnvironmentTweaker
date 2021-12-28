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
            Container.BindInterfacesAndSelfTo<RightViewController>()
                .FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<LeftViewController>()
                .FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<smile>()
                .FromNewComponentAsViewController().AsSingle();
            Container.Bind<ETSettingsFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();

            Container.BindInterfacesTo<LightManager>().AsSingle();
        }
    }
}