using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Assertions;

namespace Anycraft.Features.SceneScripting
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
        public virtual UniTask StartAsync()
            => UniTask.CompletedTask;
    }
}