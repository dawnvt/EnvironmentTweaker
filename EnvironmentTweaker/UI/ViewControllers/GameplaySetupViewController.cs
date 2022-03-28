using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Zenject;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.BSML.GameplaySetup.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\BSML\GameplaySetup.bsml")]
    public class GameplaySetupViewController : BSMLAutomaticViewController, IInitializable, IDisposable
    {
        public void Initialize()
        {
            // TODO: Make it initialize in time
        }

        public void Dispose()
        {
            // TODO: Make it dispose in time
        }
    }
}