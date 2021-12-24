using SiraUtil.Tools;
using IPALogger = IPA.Logging.Logger;
using System;
using SiraUtil.Logging;
using Zenject;

namespace EnvironmentTweaker.Managers
{
    internal class LightManager : IInitializable, IDisposable
    {
        private readonly SiraLog _log;
        private readonly LightWithIdManager _lightWithIdManager;

        public LightManager(LightWithIdManager lightWithIdManager, SiraLog log)
        {
            _lightWithIdManager = lightWithIdManager;
            _log = log;
        }

        public void Initialize()
        {
            var currentColorAndIntensityForCurrentLightID = _lightWithIdManager.GetColorForId(1);
#if DEBUG
            _log.Debug(currentColorAndIntensityForCurrentLightID);
#endif
            
            
        }

        public void Dispose()
        { }
    }
}
