using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public interface ISceneScriptStartable
        : ISceneScript
    {
        UniTask StartAsync();
    }

    [UsedImplicitly]
    public interface ISceneScriptStartable<TData>
        : ISceneScript
    {
        UniTask StartAsync(TData data);
    }
}