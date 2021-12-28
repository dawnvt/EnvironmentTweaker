using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [ViewDefinition("EnvironmentTweaker.UI.BSML.smile.bsml")]
    [HotReload(RelativePathToLayout = @"..\UI\BSML\smile.bsml")]
    public class smile : BSMLAutomaticViewController
    {
        // This class exists purely because there is no way
        // to pass an entirely blank viewcontroller to the mainViewController
        // in HMUIs "ProvideInitialViewControllers()" method.
    }
}