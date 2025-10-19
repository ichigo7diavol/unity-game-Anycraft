using Anycraft.Features.Ui.Popups.Services;
using Anycraft.Features.VContainerExtenions;
using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Anycraft.Features.Ui.Popups.Presenters.Installers
{
    [UsedImplicitly]
    public abstract class BaseUiMonoInstaller<TPopupsMediator>
        : BaseMonoInstaller
        where TPopupsMediator : BasePopupsMediator
    {
        [Required]
        [SerializeField] private UiPresenter _uiPresenter;

        [Required]
        [SerializeField] private PopupsPresenter _popupsPresenter;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.Register<PopupsService>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TPopupsMediator>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterComponent(_uiPresenter)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterComponent(_popupsPresenter)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.AsLazy<TPopupsMediator>();
        }
    }
}