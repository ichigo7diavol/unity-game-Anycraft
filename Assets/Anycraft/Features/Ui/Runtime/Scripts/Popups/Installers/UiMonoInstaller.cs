using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Ui.Popups.Presenters.Installers
{
    [UsedImplicitly]
    public sealed class UiMonoInstaller
        : BaseMonoInstaller
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
        }
    }
}