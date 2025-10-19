using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.SceneScripting
{
    [UsedImplicitly]
    public interface ISceneScript
    {
        UniTask StartAsync();
    }
}