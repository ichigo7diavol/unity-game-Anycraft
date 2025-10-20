using System;
using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneScripting
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

        public UniTask StartScriptAsync<TSceneScript>()
            where TSceneScript : ISceneScriptStartable
        {
            if (_script is not TSceneScript script)
            {
                throw new InvalidOperationException();
            }
            return script.StartAsync();
        }

        public UniTask StartScriptAsync<TSceneScript, TData>(TData data)
            where TSceneScript : ISceneScriptStartable<TData>
        {
            if (_script is not TSceneScript script)
            {
                throw new InvalidOperationException();
            }
            return script.StartAsync(data);
        }

        public void Dispose()
        {
        }
    }
}