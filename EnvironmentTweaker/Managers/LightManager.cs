using IPALogger = IPA.Logging.Logger;
using System;
using EnvironmentTweaker.Utilities;
using SiraUtil.Logging;
using Zenject;

namespace EnvironmentTweaker.Managers
{
    // TODO: Implement LightUtils.cs in ETLightManager
    internal class ETLightManager : IInitializable, IDisposable
    {
        private readonly SiraLog _log;
        private LightUtils _lights;

        public ETLightManager(SiraLog log, LightUtils lights)
        {
            _log = log;
            _lights = lights;
        }

        public void Initialize()
        { 
            // TODO: Implement initialization of LightManager
        }

        private void SetNewLightIntensity()
        {
            // TODO: ??????
        }

        public void Dispose()
        {
            // TODO: Implement disposal of LightManager
        }
    }
}
