using System;
using IPA.Config;
using UnityEngine;

namespace EnvironmentTweaker.Configuration.Base
{
    internal abstract class BaseConfig<T> where T : class
    {
        internal static T Instance { get; set; }

        public virtual void Changed()
        {
            // this exists purely because BSIPA expects virtual for configs. :)
        }

        public virtual IDisposable ChangeTransaction => null!;
    }
}