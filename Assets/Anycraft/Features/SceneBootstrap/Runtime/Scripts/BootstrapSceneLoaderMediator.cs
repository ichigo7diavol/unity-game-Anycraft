using Anycraft.Features.SceneLoader;
using Anycraft.Features.SceneMenu;
using JetBrains.Annotations;
using MessagePipe;
using Sirenix.Utilities.Editor.Expressions;
using Cysharp.Threading.Tasks;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    public sealed class BootstrapSceneLoaderServiceMediator
        : BaseSceneLoaderServiceMediator
    {
        public BootstrapSceneLoaderServiceMediator
        (
            SceneLoaderService service,
            ISubscriber<LoadSceneEvent<MenuSceneScript>> loadSceneMenuSubscriber
        )
            : base(service)
        {
            loadSceneMenuSubscriber
                .Subscribe(OnLoadScene)
                .AddTo(CtsToken);
        }
    }
}