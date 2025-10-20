using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    public abstract class BaseSceneLoaderServiceMediator
    {
        private SceneLoaderService _service;

        protected SceneLoaderService Service => _service;

        protected BaseSceneLoaderServiceMediator(SceneLoaderService service)
        {
            Assert.IsNotNull(service);

            _service = service;
        }
    }
}