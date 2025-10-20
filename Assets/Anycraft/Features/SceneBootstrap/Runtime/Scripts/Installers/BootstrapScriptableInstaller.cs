using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.SceneBootstrap
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(SceneBootstrap) + "/" + nameof(BootstrapScriptableInstaller))]
    public sealed class BootstrapScriptableInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);
        }
    }
}
