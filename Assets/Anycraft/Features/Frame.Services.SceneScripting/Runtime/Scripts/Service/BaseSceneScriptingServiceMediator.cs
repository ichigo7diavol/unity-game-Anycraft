using JetBrains.Annotations;
using NUnit.Framework;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScriptingServiceMediator
    {
        private readonly SceneScriptingService _service;

        public BaseSceneScriptingServiceMediator(SceneScriptingService service)
        {
            Assert.IsNotNull(service);
            
            _service = service;
        }
    }
}