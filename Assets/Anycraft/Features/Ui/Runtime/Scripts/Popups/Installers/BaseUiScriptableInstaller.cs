using Anycraft.Features.VContainerExtenions;
using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using VContainer;
using VContainer.Unity;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public abstract class BaseUiScriptableInstaller<TPopupsMediator>
        : BaseScriptableInstaller
        where TPopupsMediator : BasePopupsMediator
    {
        public const string GlobalContainerName = "[Ui]--Global";
        public const string LocalContainerName = "[Ui]--Local";

        [Required]
        [SerializeField] private UiPresenter _uiPresenterPrefab;
        
        [Required]
        [SerializeField] private PopupsServiceConfig _serviceConfig;

        [SerializeField] private bool _isGlobal;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            Assert.IsNotNull(_uiPresenterPrefab);
            Assert.IsNotNull(_serviceConfig);

            var container = CreateContainer();

            builder.RegisterInstance(_serviceConfig)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<PopupsService>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TPopupsMediator>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            var uiPreenter = Instantiate(_uiPresenterPrefab, container.transform);
            builder.RegisterComponent(uiPreenter)
                .AsSelf()
                .AsImplementedInterfaces();

            var popupsPresenter = uiPreenter.GetComponentInChildren<PopupsPresenter>();
            builder.RegisterComponent(popupsPresenter)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.AsLazy<TPopupsMediator>();
        }

        private GameObject CreateContainer()
        {
            var containerName = _isGlobal
                ? GlobalContainerName
                : LocalContainerName;

            var container = new GameObject(containerName);

            if (_isGlobal)
            {
                DontDestroyOnLoad(container);
            }
            return container;
        }
    }
}