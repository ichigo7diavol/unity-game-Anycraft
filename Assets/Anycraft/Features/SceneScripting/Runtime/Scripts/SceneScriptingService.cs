using System;
using System.Threading;
using Anycraft.FluentValidationExtensions.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer.Unity;

namespace Anycraft.FluentValidationExtensions.SceneScripting
{

    [UsedImplicitly]
    public sealed partial class SceneScriptingService
        : IService, IAsyncStartable
    {
        private BaseSceneScript _script;

        public SceneScriptingService(BaseSceneScript script)
        {
            Assert.IsNotNull(script);

            _script = script;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            cancellation.ThrowIfCancellationRequested();

            try
            {
                await _script.StartAsync(cancellation);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}