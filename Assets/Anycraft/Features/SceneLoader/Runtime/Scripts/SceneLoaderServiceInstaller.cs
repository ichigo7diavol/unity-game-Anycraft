using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneLoader
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneLoader) + "/" + nameof(SceneLoaderServiceInstaller))]
    public sealed class SceneLoaderServiceInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.Register<SceneLoaderService>(Lifetime.Scoped)
                .AsImplementedInterfaces()
                .AsSelf();
        }
    }
}