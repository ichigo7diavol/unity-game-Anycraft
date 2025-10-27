using System;
using Anycraft.Features.Services;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
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

        public UniTask StartAsync()
        {
            return _script.StartAsync();
        }

        public UniTask StartBuildAsync<TSceneScript>()
            where TSceneScript : ISceneScriptBuildable
        {
            if (_script is not TSceneScript script)
            {
                throw new InvalidOperationException();
            }
            return script.BuildAsync();
        }

        public UniTask StartBuildAsync<TSceneScript, TData>(TData data)
            where TSceneScript : ISceneScriptBuildable<TData>
        {
            if (_script is not TSceneScript script)
            {
                throw new InvalidOperationException();
            }
            return script.BuildAsync(data);
        }

        public void Dispose()
        {
        }
    }
}