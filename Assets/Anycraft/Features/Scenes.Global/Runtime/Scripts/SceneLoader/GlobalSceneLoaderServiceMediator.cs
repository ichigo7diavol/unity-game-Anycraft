using Anycraft.Features.SceneLoader;
using Anycraft.Features.SceneMenu;
using JetBrains.Annotations;
using MessagePipe;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;

namespace Anycraft.Features.Global
{
    [UsedImplicitly]
    public sealed class GlobalSceneLoaderServiceMediator
        : BaseSceneLoaderServiceMediator
    {
        private readonly GlobalSceneLoaderServiceMediatorConfig _config;

        public GlobalSceneLoaderServiceMediator
        (
            SceneLoaderService service,
            GlobalSceneLoaderServiceMediatorConfig config,
            ISubscriber<LoadSceneEvent<MenuSceneScript>> loadSceneMenuSubscriber
        )
            : base(service)
        {
            Assert.IsNotNull(_config);

            _config = config;

            loadSceneMenuSubscriber
                .Subscribe(OnLoadSceneMenu)
                .AddTo(CtsToken);
        }

        private void OnLoadSceneMenu(LoadSceneEvent<MenuSceneScript> _)
        {
            Service
                .LoadSceneAndRunScriptAsync<MenuSceneScript>(_config.MenuSceneReference)
                .Forget();
        }
    }
}