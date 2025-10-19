using Anycraft.Features.Ui.Popups.Services;
using Anycraft.Features.VContainerExtenions;
using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

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

            builder.RegisterInstance(_uiPresenter)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterInstance(_popupsPresenter)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register<TPopupsMediator>(Lifetime.Singleton)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.AsLazy<TPopupsMediator>();
        }
    }
}