using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public interface ISceneScriptBuildable
        : ISceneScript
    {
        UniTask BuildAsync();
    }

    [UsedImplicitly]
    public interface ISceneScriptBuildable<TData>
        : ISceneScript
    {
        UniTask BuildAsync(TData data);
    }
}