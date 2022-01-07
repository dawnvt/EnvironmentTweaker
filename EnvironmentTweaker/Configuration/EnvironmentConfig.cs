using System.Runtime.CompilerServices;
using EnvironmentTweaker.Configuration.Base;
using IPA.Config.Stores.Attributes;

[assembly: InternalsVisibleTo(IPA.Config.Stores.GeneratedStore.AssemblyVisibilityTarget)]
namespace EnvironmentTweaker.Configuration
{
    [NotifyPropertyChanges]
    internal class EnvironmentConfig : BaseConfig<EnvironmentConfig>
    {
        public virtual bool IsEnabled { get; set; }
        public virtual string EnvString { get; set; }
    }
}