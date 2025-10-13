using JetBrains.Annotations;

namespace Anycraft.Features.Validation
{
    [UsedImplicitly]
    public interface IValidatable
    {
        bool Validate(ref string errorMessage);
    }
}

