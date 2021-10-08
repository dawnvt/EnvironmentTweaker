using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Settings;
using IPA.Config.Data;
using LightDimmer.Configuration;
using Zenject;

namespace LightDimmer.UI.ViewControllers
{
    [ViewDefinition("LightDimmer.UI.ModSettingsView.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\ModSettingsView.bsml")]
    public class ModSettingsViewController : PersistentSingleton<ModSettingsViewController>, IInitializable, IDisposable
    {
        public void Initialize()
        {
            BSMLSettings.instance.AddSettingsMenu("LightDimmer", "LightDimmer.UI.ModSettingsView.bsml", this);
        }

        public void Dispose()
        {
            BSMLSettings.instance.RemoveSettingsMenu(this);
        }
    }
}