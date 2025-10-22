using Anycraft.Features.Extenions.VContainer;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.Extensions.MessagePipe
{
    [UsedImplicitly]
    [CreateAssetMenu(menuName = nameof(Anycraft) + "/" + nameof(Features) + "/" +  nameof(Extensions) + "/" + nameof(MessagePipeScriptableInstaller))]
    public sealed class MessagePipeScriptableInstaller
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