using EnvironmentTweaker.Managers;
using EnvironmentTweaker.UI;
using EnvironmentTweaker.UI.FlowCoordinators;
using EnvironmentTweaker.UI.ViewControllers;
using HMUI;
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
            
            Container.BindInterfacesAndSelfTo<ViewController>()
                .FromNewComponentAsViewController().AsSingle();
            
            Container.BindInterfacesTo<FloatingChangelogViewController>()
                .FromNewComponentAsViewController().AsSingle();
            
            Container.Bind<ETSettingsFlowCoordinator>()
                .FromNewComponentOnNewGameObject().AsSingle();

            Container.BindInterfacesTo<ETLightManager>().AsSingle();
        }
    }
}