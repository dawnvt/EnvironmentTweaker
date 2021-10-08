using System.Runtime.CompilerServices;
using Config = IPA.Config.Stores;

[assembly: InternalsVisibleTo(Config.GeneratedStore.AssemblyVisibilityTarget)]
namespace LightDimmer.Configuration
{
    public class PluginConfig
    {
        public virtual bool Enabled { get; set; }
        public virtual float Intensity { get; set; }
    }
}