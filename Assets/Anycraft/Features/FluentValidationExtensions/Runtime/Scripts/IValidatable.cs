using JetBrains.Annotations;

namespace Anycraft.Features.FluentValidationExtensions
{
    [UsedImplicitly]
    public interface IValidatable
    {
        void Validate();
    }
}