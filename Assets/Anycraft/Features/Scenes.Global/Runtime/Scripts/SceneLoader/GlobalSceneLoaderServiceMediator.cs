using JetBrains.Annotations;
using MessagePipe;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;
using Anycraft.Features.Frame.Services.SceneLoader;
using Anycraft.Features.Scenes.Main;
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
            ISubscriber<LoadSceneEvent<MainSceneScript>> loadSceneMenuSubscriber
        )
            : base(service)
        {
            Assert.IsNotNull(config);

            _config = config;

            loadSceneMenuSubscriber
                .Subscribe(OnLoadSceneMenu)
                .AddTo(CtsToken);
        }

        private void OnLoadSceneMenu(LoadSceneEvent<MainSceneScript> _)
        {
            Service.LoadSceneAndRunScriptAsync<
                MainSceneLifetimeScope, MainSceneScript>(_config.MenuSceneReference)
                .Forget();
        }
    }
}