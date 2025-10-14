using Anycraft.FluentValidationExtensions.Validation;
using JetBrains.Annotations;

namespace Anycraft.FluentValidationExtensions.Configs
{
    [UsedImplicitly]
    public interface IConfig : IValidatable
    {
        public string Id { get; }
    }
}