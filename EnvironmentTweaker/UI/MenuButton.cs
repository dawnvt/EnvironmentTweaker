using BeatSaberMarkupLanguage.MenuButtons;
using System;
using BeatSaberMarkupLanguage;
using EnvironmentTweaker.UI.FlowCoordinators;
using Zenject;

namespace EnvironmentTweaker.UI
{
    public class MenuButtonUI : IInitializable, IDisposable
    {
        private readonly MenuButton _menuButton;
        [Inject] private MainFlowCoordinator _mainFlowCoordinator;
        [Inject] private SettingsFlowCoordinator _settingsFlowCoordinator;

        public MenuButtonUI(SettingsFlowCoordinator settingsFlowCoordinator)
        {
            _menuButton = new MenuButton("EnvironmentTweaker", "Tweak the environment!", InvokeFlowCoordinator, false);
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(_menuButton);
        }

        private void InvokeFlowCoordinator()
        {
            _mainFlowCoordinator.PresentFlowCoordinator(_settingsFlowCoordinator);
        }

        public void Dispose()
        {
            if (MenuButtons.instance != null)
                MenuButtons.instance.UnregisterButton(_menuButton);
            _mainFlowCoordinator.DismissFlowCoordinator(_settingsFlowCoordinator);
        }
    }
}