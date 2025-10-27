using System;
using System.Threading;
using Anycraft.Features.Frame.Logger;
using Anycraft.Features.Frame.Services.SceneScripting;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.Frame.Services.SceneLoader
{
    [UsedImplicitly]
    public readonly struct LoadSceneEvent<TSceneScript>
        where TSceneScript : ISceneScript, ISceneScriptBuildable
    {
    }

    [UsedImplicitly]
    public readonly struct LoadSceneEvent<TSceneScript, TSceneScriptData>
        where TSceneScript : ISceneScript, ISceneScriptBuildable<TSceneScriptData>
    {
        public readonly TSceneScriptData Data;
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
    }
}