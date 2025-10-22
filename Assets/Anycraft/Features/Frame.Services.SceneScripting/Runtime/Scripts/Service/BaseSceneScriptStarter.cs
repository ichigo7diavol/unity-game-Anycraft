using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;
using VContainer.Unity;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScriptStarter<TSceneScript, TData>
        : IStartable
        where TSceneScript : ISceneScript, ISceneScriptStartable<TData>
    {
        private readonly SceneScriptingService _service;
        private readonly TData _data;

        public BaseSceneScriptStarter(SceneScriptingService service, TData data)
        {
            Assert.IsNotNull(service);

            _service = service;
            _data = data;
        }

        public void Start()
        {
            _service
                .StartScriptAsync<TSceneScript, TData>(_data)
                .Forget();
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneScriptStarter<TSceneScript>
        : IStartable
        where TSceneScript : ISceneScript, ISceneScriptStartable
    {
        private readonly SceneScriptingService _service;

        public BaseSceneScriptStarter(SceneScriptingService service)
        {
            Assert.IsNotNull(service);

            _service = service;
        }

        public void Start()
        {
            _service
                .StartScriptAsync<TSceneScript>()
                .Forget();
        }
    }
}