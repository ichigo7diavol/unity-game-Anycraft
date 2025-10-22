using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Ui
{
    [UsedImplicitly]
    public abstract class BasePopupScriptableInstaller<TPopupPresenter>
        : BaseScriptableInstaller
        where TPopupPresenter : BasePopupPresenter
    {
        [Required]
        [SerializeField] private TPopupPresenter _prefab;

        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.RegisterInstance<TPopupPresenter, BasePopupPresenter>(_prefab)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}