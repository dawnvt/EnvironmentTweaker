using System;
using HMUI;
using Zenject;
using EnvironmentTweaker.Utils;

namespace EnvironmentTweaker.UI.FlowCoordinators
{
    public class SettingsFlowCoordinator : FlowCoordinator
    {
        private bool _hasTransitioned = false;

        [Inject] private MenuTransitionsHelper _menuTransitionsHelper;
        [Inject] private MenuEnvironmentManager _menuEnvironment;
        [Inject] private GameScenesManager _gameScenesManager;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (addedToHierarchy)
            {
                showBackButton = true;
                SetTitle("EnvironmentTweaker");
            }
        }

        public void DoSceneTransition(Action callback = null)
        {
            if (_hasTransitioned) return;
            _hasTransitioned = true;

            /*persistentScenes = GSMPersistentScenes(ref _gameScenesManager);

            var tutorialSceneSetup = MTHTutorialScenesSetup(ref _menuTransitionsHelper);
            tutorialSceneSetup.Init();
            
            _menuEnvironment.ShowEnvironmentType(MenuEnvironmentManager.MenuEnvironmentType.None);
            _gameScenesManager.PushScenes(tutorialSceneSetup, 0.25f, null, (_) =>
            {
                
            });*/
        }
    }
}