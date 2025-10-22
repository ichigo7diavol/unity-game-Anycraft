using System;
using System.Threading;
using Anycraft.Features.Logger;
using Anycraft.Features.SceneScripting;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    public readonly struct LoadSceneEvent<TSceneScript>
        where TSceneScript : ISceneScript, ISceneScriptStartable
    {
        public readonly SceneReference SceneReference;

        public LoadSceneEvent(SceneReference sceneReference)
        {
            Assert.IsNotNull(sceneReference);

            SceneReference = sceneReference;
        }
    }

    [UsedImplicitly]
    public readonly struct LoadSceneEvent<TSceneScript, TSceneScriptData>
        where TSceneScript : ISceneScript, ISceneScriptStartable<TSceneScriptData>
    {
        public readonly SceneReference SceneReference;
        public readonly TSceneScriptData Data;

        public LoadSceneEvent(SceneReference sceneReference, TSceneScriptData data)
        {
            Assert.IsNotNull(sceneReference);

            SceneReference = sceneReference;
            Data = data;
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneLoaderServiceMediator
        : IDisposable
    {
        private readonly CancellationTokenSource _cts = new();
        private SceneLoaderService _service;

        protected CancellationToken CtsToken => _cts.Token;
        protected SceneLoaderService Service => _service;

        protected BaseSceneLoaderServiceMediator(SceneLoaderService service)
        {
            this.LogStepStarted($"Mediator '{GetType().Name}' creation");

            Assert.IsNotNull(service);

            _service = service;

            this.LogStepCompleted($"Mediator '{GetType().Name}' creation");
        }

        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
        }

        protected void OnLoadScene<TSceneScript>(LoadSceneEvent<TSceneScript> eventData)
            where TSceneScript : ISceneScript, ISceneScriptStartable
        {
            this.LogDebug($"Loading scene: '{eventData.SceneReference}'");

            Service
                .LoadSceneAndRunScriptAsync<TSceneScript>(eventData.SceneReference)
                .Forget();
        }

        protected void OnLoadScene<TSceneScript, TSceneScriptData>(
            LoadSceneEvent<TSceneScript, TSceneScriptData> eventData)
            where TSceneScript : ISceneScript, ISceneScriptStartable<TSceneScriptData>
        {
            this.LogDebug($"Loading scene: '{eventData.SceneReference}'");

            Service
                .LoadSceneAndRunScriptAsync<TSceneScript, TSceneScriptData>(
                    eventData.SceneReference, eventData.Data)
                .Forget();
        }
    }
}