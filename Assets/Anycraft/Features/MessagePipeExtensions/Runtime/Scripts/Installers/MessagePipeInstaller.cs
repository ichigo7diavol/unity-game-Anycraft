using Anycraft.Features.VContainerExtenions.Installers;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.MessagePipeExtensions.Installers
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" + nameof(MessagePipeExtensions) + "/" + nameof(Installers) + "/" + nameof(MessagePipeInstaller))]
    public sealed class MessagePipeInstaller
        : BaseScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            base.Install(builder);

            builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(
                c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        }
    }
}