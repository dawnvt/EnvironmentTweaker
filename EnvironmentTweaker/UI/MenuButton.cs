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
        private readonly MainFlowCoordinator _mainFlowCoordinator;
        private ETSettingsFlowCoordinator _ETFlowCoordinator;

        public MenuButtonUI(MainFlowCoordinator mainFlowCoordinator, ETSettingsFlowCoordinator ETFlowCoordinator)
        {
            _mainFlowCoordinator = mainFlowCoordinator;
            _ETFlowCoordinator = ETFlowCoordinator;
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(new MenuButton("EnvironmentTweaker", "Tweak your environment!", InvokeFlowCoordinator)); 
        }

        private void InvokeFlowCoordinator()
        {
            Console.WriteLine(_ETFlowCoordinator);
            _mainFlowCoordinator.PresentFlowCoordinator(_ETFlowCoordinator);
        }

        public void Dispose()
        { }
    }
}