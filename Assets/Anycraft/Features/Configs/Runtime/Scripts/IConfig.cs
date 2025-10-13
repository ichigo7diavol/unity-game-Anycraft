using Anycraft.Features.Validation;
using JetBrains.Annotations;

namespace Anycraft.Features.Configs
{
    [UsedImplicitly]
    public interface IConfig : IValidatable
    {
        public string Id { get; }
    }
}