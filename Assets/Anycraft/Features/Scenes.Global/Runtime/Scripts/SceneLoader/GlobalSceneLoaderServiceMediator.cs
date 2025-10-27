using JetBrains.Annotations;
using MessagePipe;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Scenes.SceneMenu;
using System.Threading;

namespace Anycraft.Features.Scenes.Global
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
            Assert.IsNotNull(config);

            _config = config;

            loadSceneMenuSubscriber
                .Subscribe(OnLoadSceneMenu)
                .AddTo(CtsToken);
        }

        private void OnLoadSceneMenu(LoadSceneEvent<MenuSceneScript> _)
        {
            Service.LoadSceneAndRunScriptAsync<
                MenuSceneLifetimeScope, MenuSceneScript>(_config.MenuSceneReference)
                .Forget();
        }
    }
}