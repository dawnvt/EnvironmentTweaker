using System.Reflection;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using UnityEngine;

namespace EnvironmentTweaker.Utilities
{
    public class UIUtils
    {
        public FloatingScreen CreateFloatingScreen(object host, Vector3 pos, Quaternion rot)
        {
            FloatingScreen floatingScreen =
                FloatingScreen.CreateFloatingScreen(new Vector2(0f, 0f), false, pos, rot, 0, true);
            BSMLParser.instance.Parse(
                BeatSaberMarkupLanguage
                    .Utilities
                    .GetResourceContent(Assembly.GetExecutingAssembly(),
                    "EnvironmentTweaker.UI.BSML.Changelog.bsml"), floatingScreen.gameObject, host);
            return floatingScreen;
        }
    }
}