using System;
using BeatSaberMarkupLanguage;
using EnvironmentTweaker.UI.ViewControllers;
using HMUI;
using SiraUtil.Logging;
using Zenject;

namespace EnvironmentTweaker.UI.FlowCoordinators
{
    public class ETSettingsFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator _mainFlowCoordinator;
        private smile _smile;
        private LeftViewController _leftViewController;
        private RightViewController _rightViewController;
        private SiraLog _siraLog;
        
        [Inject]
        public void Construct(MainFlowCoordinator mainFlowCoordinator, smile smile, LeftViewController leftViewController, RightViewController rightViewController, SiraLog siraLog)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _smile = smile;
            _leftViewController = leftViewController;
            _rightViewController = rightViewController;
            _siraLog = siraLog;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {
                    SetTitle("EnvironmentTweaker");
                    showBackButton = true;
                    ProvideInitialViewControllers(_smile, _leftViewController, _rightViewController);
                }
            }
            catch (Exception e)
            {
                _siraLog.Error(e);
            }
        }
        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}