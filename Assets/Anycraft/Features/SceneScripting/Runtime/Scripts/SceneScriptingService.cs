using System;
using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer.Unity;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public sealed partial class SceneScriptingService
        : IService, IStartable
    {
        private readonly ISceneScript _script;

        public SceneScriptingService(ISceneScript script)
        {
            Assert.IsNotNull(script);

            _script = script;
        }

        public void Start()
        {
            StartAsync().Forget();
        }

        public void Dispose()
        {
        }

        private async UniTask StartAsync()
        {
            try
            {
                await _script.StartAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}