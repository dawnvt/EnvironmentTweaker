using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(IPA.Config.Stores.GeneratedStore.AssemblyVisibilityTarget)]
namespace EnvironmentTweaker.Configuration
{
    public class PluginConfig
    {
        // Bools
        public virtual bool Enabled { get; set; }
        public virtual bool EnableChangelogScreen { get; set; }
        
        // Floats
        public virtual float Intensity { get; set; }
    }
}