using JetBrains.Annotations;
using UnityEngine.Assertions;
using VContainer.Unity;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScriptStarter<TSceneScript, TData>
        : IStartable
        where TSceneScript : ISceneScript, ISceneScriptBuildable<TData>
    {
        private readonly SceneScriptingService _service;
        private readonly TData _data;

        public BaseSceneScriptStarter(SceneScriptingService service, TData data)
        {
            Assert.IsNotNull(service);

            _service = service;
            _data = data;
        }

        public async void Start()
        {
            await _service.StartBuildAsync<TSceneScript, TData>(_data);
            await _service.StartAsync();
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneScriptStarter<TSceneScript>
        : IStartable
        where TSceneScript : ISceneScript, ISceneScriptBuildable
    {
        private readonly SceneScriptingService _service;

        public BaseSceneScriptStarter(SceneScriptingService service)
        {
            Assert.IsNotNull(service);

            _service = service;
        }

        public async void Start()
        {
            await _service.StartBuildAsync<TSceneScript>();
            await _service.StartAsync();
        }
    }
}