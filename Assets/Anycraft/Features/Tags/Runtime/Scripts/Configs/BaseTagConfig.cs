using Anycraft.FluentValidationExtensions.Configs;
using JetBrains.Annotations;

namespace Anycraft.FluentValidationExtensions.Tags.Configs
{
    [UsedImplicitly]
    public abstract partial class BaseTagConfig
        : BaseSerializedConfig
    {
        public override string ToString() => $"Tag--{Id}";
    }
}

