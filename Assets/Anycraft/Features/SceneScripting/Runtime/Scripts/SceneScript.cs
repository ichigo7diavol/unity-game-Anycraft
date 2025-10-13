using System.Threading;
using Anycraft.Features.Configs;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public abstract class BaseSceneScript : BaseSerializedConfig
    {
        // public virtual async UniTask InitializeAsync() { }
        // public virtual async UniTask PostInitializeAsync() { }  

        public virtual UniTask StartAsync(CancellationToken cancellation = default) => UniTask.CompletedTask;  
        // public virtual async UniTask PostStartAsync() { }  
    }
}