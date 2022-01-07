﻿using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using SiraUtil.Web.SiraSync;
using Zenject;

namespace EnvironmentTweaker.UI.ViewControllers
{
    [HotReload(RelativePathToLayout = @"..\BSML\Changelog.bsml")]
    [ViewDefinition("EnvironmentTweaker.UI.BSML.Changelog.bsml")]
    public class FloatingChangelogViewController : BSMLAutomaticViewController
    {
        private ISiraSyncService siraSyncService;
        private string _changelog;

        [Inject]
        public void Construct(ISiraSyncService siraSyncService)
        {
            this.siraSyncService = siraSyncService;
        }

        [UIAction("#post-parse")]
        private async void PostParse()
        {
            string rawChangelog = await siraSyncService.LatestChangelog();
            Changelog = await Task.Run(() => MarkdownParse(rawChangelog));
        }

        private string MarkdownParse(string original)
        {
            // We do a little filtering using regex
            original = Regex.Replace(original, @"!\[.*\]\(.*\)\r\n", ""); // No images with line breaks
            original = Regex.Replace(original, @"!\[.*\]\(.*\)", ""); // No images
            original = Regex.Replace(original, @"(\[)(.*)(\]\(.*\))", "$2"); // No hyperlinks

            // Newlines need to be doubled
            original = original.Replace("\n", "\n\n");

            // I will not need more than 3 headings
            original = Regex.Replace(original, @"(### )(.*)", "<size=5.75>$2</size>\n"); // Heading 3
            original = Regex.Replace(original, @"(## )(.*)", "<size=6>$2</size>\n<color=#ffffff80>________________________________________________________</color>"); // Heading 2
            original = Regex.Replace(original, @"(# )(.*)", "<size=7>$2</size>\n<color=#ffffff80>________________________________________________________</color>"); // Heading 1

            return original;
        }

        [UIValue("is-loading")]
        private bool IsLoading => string.IsNullOrEmpty(Changelog);

        [UIValue("loaded")]
        private bool Loaded => !string.IsNullOrEmpty(Changelog);

        [UIValue("changelog")]
        private string Changelog
        {
            get => _changelog;
            set
            {
                _changelog = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IsLoading));
                NotifyPropertyChanged(nameof(Loaded));
            }
        }
    }
}