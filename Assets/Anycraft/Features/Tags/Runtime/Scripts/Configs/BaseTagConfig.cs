using Anycraft.Features.Configs;
using JetBrains.Annotations;

namespace Anycraft.Features.Tags.Configs
{
    [UsedImplicitly]
    public abstract partial class BaseTagConfig
        : BaseSerializedConfig
    {
        public override string ToString() => $"Tag--{Id}";
    }
}

