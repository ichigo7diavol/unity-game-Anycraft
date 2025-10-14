using JetBrains.Annotations;

namespace Anycraft.FluentValidationExtensions.Validation
{
    [UsedImplicitly]
    public interface IValidatable
    {
        void Validate();
    }
}