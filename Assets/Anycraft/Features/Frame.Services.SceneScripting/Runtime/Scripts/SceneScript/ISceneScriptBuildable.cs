using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public interface ISceneScriptBuildable
    {
        UniTask BuildAsync();
    }

    [UsedImplicitly]
    public interface ISceneScriptBuildable<TData>
    {
        UniTask BuildAsync(TData data);
    }
}