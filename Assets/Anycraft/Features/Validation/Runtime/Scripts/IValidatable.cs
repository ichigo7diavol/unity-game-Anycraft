using JetBrains.Annotations;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    public interface IValidatable
    {
        void Validate();
    }
}