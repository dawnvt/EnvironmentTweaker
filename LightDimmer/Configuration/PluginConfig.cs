﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(IPA.Config.Stores.GeneratedStore.AssemblyVisibilityTarget)]
namespace LightDimmer.Configuration
{
    internal class PluginConfig
    {
        public virtual bool Enabled { get; set; }
        public virtual float Intensity { get; set; }
    }
}