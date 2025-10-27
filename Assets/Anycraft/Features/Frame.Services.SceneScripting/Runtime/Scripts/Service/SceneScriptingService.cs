using System;
using Anycraft.Features.Frame.Logger;
using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public sealed partial class SceneScriptingService
        : IService
    {
        private readonly ISceneScript _script;

        public SceneScriptingService(ISceneScript script)
        {
            Assert.IsNotNull(script);

            _script = script;
        }

        public async UniTask StartAsync()
        {
            var logStep = $"script '{_script.GetType().Name}' STARTING";

            this.LogStepStarted(logStep);
            try
            {
                await _script.StartAsync();
            }
            catch (Exception e)
            {
                this.LogStepInterrupted(logStep);
                Debug.LogException(e);
                throw;
            }
            this.LogStepCompleted(logStep);
        }

        public async UniTask StartBuildAsync<TSceneScript>()
            where TSceneScript : ISceneScriptBuildable
        {
            var logStep = $"script '{_script.GetType().Name}' BUILDING";

            this.LogStepStarted(logStep);
            try
            {
                if (_script is not TSceneScript script)
                {
                    throw new InvalidOperationException();
                }
                await script.BuildAsync();
            }
            catch (Exception e)
            {
                this.LogStepInterrupted(logStep);
                Debug.LogException(e);
                throw;
            }
            this.LogStepCompleted(logStep);
        }

        public async UniTask StartBuildAsync<TSceneScript, TData>(TData data)
            where TSceneScript : ISceneScriptBuildable<TData>
        {
            var logStep = $"script '{_script.GetType().Name}' BUILDING";

            this.LogStepStarted(logStep);
            try
            {
                if (_script is not TSceneScript script)
                {
                    throw new InvalidOperationException();
                }
                await script.BuildAsync(data);
            }
            catch (Exception e)
            {
                this.LogStepInterrupted(logStep);
                Debug.LogException(e);
                throw;
            }
            this.LogStepCompleted(logStep);
        }

        public void Dispose()
        {
        }
    }
}