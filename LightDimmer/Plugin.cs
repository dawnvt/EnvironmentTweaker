using BeatSaberMarkupLanguage.Settings;
using IPA;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using LightDimmer.Configuration;
using LightDimmer.Installers;
using LightDimmer.UI.ViewControllers;
using SiraUtil.Tools;

namespace LightDimmer
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private PluginConfig _config;
        private IPALogger _logger;
        private ModSettingsViewController _settingsViewController;

        [Init]
        public void Init(Zenjector zenjector, PluginConfig config, IPALogger logger,
            ModSettingsViewController settingsViewController)
        {
            _config = config;
            _logger = logger;
            _settingsViewController = settingsViewController;


            BSMLSettings.instance.AddSettingsMenu("LightDimmer", "LightDimmer.UI.ModSettingsView.bsml",
                _settingsViewController);
            zenjector.OnMenu<MenuInstaller>().WithParameters(_config);
        }

        [OnEnable, OnDisable]
        public void OnStateChanged()
        {
        }
    }
}
