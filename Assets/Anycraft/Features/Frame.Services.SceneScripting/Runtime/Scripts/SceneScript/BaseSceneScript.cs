using Anycraft.Features.Frame.Logger;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScript<TConfig>
        : BaseSceneScript
        where TConfig : BaseSceneScriptConfig
    {
        public TConfig Config { get; }

        protected BaseSceneScript(TConfig config)
        {
            Assert.IsNotNull(config);

            Config = config;
        }
    }

    [UsedImplicitly]
    public abstract class BaseSceneScript
        : ISceneScript
    {
        public UniTask StartAsync()
        {
            this.LogDebug("Scene started STUB");

            return UniTask.CompletedTask;
        }
    }
}