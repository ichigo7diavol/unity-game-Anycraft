using Anycraft.Features.Extenions.VContainer;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Anycraft.Features.Services
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(Services) + "/" + nameof(ServiceInspectorScriptableInstaller))]
    public sealed class ServiceInspectorScriptableInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.RegisterComponentOnNewGameObject<ServicesInspector>(
                Lifetime.Singleton, $"[{nameof(ServicesInspector)}]")
                .AsSelf()
                .AsImplementedInterfaces();

            builder.AsLazy<ServicesInspector>();
        }
    }
}