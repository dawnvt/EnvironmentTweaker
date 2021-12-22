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
            _log.Logger.Info($"parent: {_lightWithIdManager.transform.parent.gameObject.name}");
        }

        public void Dispose()
        {
            _log.Logger.Info($"unparent: {_lightWithIdManager.transform.parent.gameObject.name}");
        }
    }
}
