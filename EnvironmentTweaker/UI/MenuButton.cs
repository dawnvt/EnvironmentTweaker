using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using EnvironmentTweaker.UI.FlowCoordinators;
using IPALogger = IPA.Logging.Logger;
using Zenject;

namespace EnvironmentTweaker.UI
{
    public class MenuButtonUI : IInitializable, IDisposable
    {
        private MenuButton _menuButton;
        private readonly MainFlowCoordinator _mainFlowCoordinator;
        private ETSettingsFlowCoordinator _ETFlowCoordinator;

        public MenuButtonUI(MainFlowCoordinator mainFlowCoordinator, ETSettingsFlowCoordinator ETFlowCoordinator)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _ETFlowCoordinator = ETFlowCoordinator;
            _menuButton = new MenuButton("EnvironmentTweaker", "Tweak your environment!", InvokeFlowCoordinator);
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(_menuButton); 
        }

        private void InvokeFlowCoordinator()
        {
            _mainFlowCoordinator.PresentFlowCoordinator(_ETFlowCoordinator);
        }

        public void Dispose()
        {
            if (BSMLParser.IsSingletonAvailable && MenuButtons.IsSingletonAvailable)
            {
                MenuButtons.instance.UnregisterButton(_menuButton);
            }
        }
    }
}