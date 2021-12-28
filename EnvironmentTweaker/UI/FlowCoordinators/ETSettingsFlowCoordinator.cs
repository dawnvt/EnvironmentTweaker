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
        private SimpleSettingsViewController _simpleSettingsViewController;
        private AdvancedSettingsViewController _advancedSettingsViewController;
        private SiraLog _siraLog;
        
        public void Construct(MainFlowCoordinator mainFlowCoordinator, smile smile, SimpleSettingsViewController simpleSettingsViewController, AdvancedSettingsViewController advancedSettingsViewController, SiraLog siraLog)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _smile = smile;
            _simpleSettingsViewController = simpleSettingsViewController;
            _advancedSettingsViewController = advancedSettingsViewController;
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
                    ProvideInitialViewControllers(_smile, _advancedSettingsViewController, _simpleSettingsViewController);
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