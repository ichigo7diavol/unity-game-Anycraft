using System.Threading.Tasks;
using Anycraft.Features.Frame.Logger;
using Cysharp.Threading.Tasks;
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
            this.LogStepStarted("Scene BUILDING");
            await _service.StartBuildAsync<TSceneScript, TData>(_data);
            this.LogStepCompleted("Scene BUILDING");

            this.LogStepStarted("Scene STARTING");
            await _service.StartAsync();
            this.LogStepStarted("Scene BUILDING");
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
            this.LogStepStarted("Scene BUILDING");
            await _service.StartBuildAsync<TSceneScript>();
            this.LogStepCompleted("Scene BUILDING");

            this.LogStepStarted("Scene STARTING");
            await _service.StartAsync();
            this.LogStepStarted("Scene BUILDING");
        }
    }
}