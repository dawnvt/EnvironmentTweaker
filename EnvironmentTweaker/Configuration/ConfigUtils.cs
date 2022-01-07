using EnvironmentTweaker.Configuration.Base;
using IPA.Config;
using IPA.Config.Stores;

namespace EnvironmentTweaker.Configuration
{
    internal class ConfigUtils
    {
        public static void InitConfigs()
        {
            CreateEnvConfig<EnvironmentConfig>("TheFirst");
            CreateEnvConfig<EnvironmentConfig>("Dragons");
        }

        public static void CreateEnvConfig<T>(string configName) where T : BaseConfig<T>, new()
        {
            BaseConfig<T>.Instance = Config
                .GetConfigFor($"{nameof(EnvironmentTweaker)} - {configName}")
                .Generated<T>();
            BaseConfig<T>.Instance.Changed();
        }
    }
}
