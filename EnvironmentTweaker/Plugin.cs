using System.IO;
using EnvironmentTweaker.Configuration;
using EnvironmentTweaker.Configuration.Base;
using EnvironmentTweaker.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using IPA.Utilities;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Web.SiraSync;
using SiraUtil.Zenject;

namespace EnvironmentTweaker
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    internal class Plugin
    {
        public static string PluginUserDataPath => Path.Combine(UnityGame.UserDataPath, "EnvironmentTweaker");
        
        [Init]
        public void Init(IPALogger logger, PluginMetadata metadata, Config config, Zenjector zenjector)
        {
            Directory.CreateDirectory(PluginUserDataPath);
            
            // TODO: Figure out how the fuck this UserData subdir shit works.
            
            /* Configuration = Config
                .GetConfigFor(nameof(EnvironmentTweaker) 
                              + Path.DirectorySeparatorChar
                              + nameof(EnvironmentTweaker))
                .Generated<PluginConfig>(); */
            
            zenjector.UseLogger(logger);
            
            zenjector.UseHttpService();
            zenjector.UseSiraSync(SiraSyncServiceType.GitHub, "dawnvt");
            
            zenjector.Install<AppInstaller>(Location.App, config.Generated<PluginConfig>());
            zenjector.Install<ETMenuInstaller>(Location.Menu);
            zenjector.Install<ETGameInstaller>(Location.GameCore);
            
            ConfigUtils.InitConfigs();
        }
    }
}
