using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Anycraft.Features.Frame.Services.SceneScripting
{
    [UsedImplicitly]
    public interface ISceneScript
    {
        UniTask StartAsync();
    }
}