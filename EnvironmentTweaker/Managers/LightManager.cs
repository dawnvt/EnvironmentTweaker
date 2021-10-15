using SiraUtil.Tools;
using System;
using Zenject;

namespace EnvironmentTweaker.Managers
{
    internal class LightManager : IInitializable, IDisposable
    {
        private readonly SiraLog _log;
        private readonly LightWithIdManager _lightWithIdManager;

        public LightManager(SiraLog logger, LightWithIdManager lightWithIdManager)
        {
            _log = logger;
            _lightWithIdManager = lightWithIdManager;
        }

        public void Initialize()
        {
            _log.Info($"parent: {_lightWithIdManager.transform.parent.gameObject.name}");
        }

        public void Dispose()
        { }
    }
}
