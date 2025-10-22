using JetBrains.Annotations;

namespace Anycraft.Features.Extensions.FluentValidation
{
    [UsedImplicitly]
    public interface IValidatable
    {
        void Validate();
    }
}