using Anycraft.Features.Validation;
using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public abstract class MonoContainerInstaller : IContainerInstaller, IValidatable
    {
        public virtual void Install(IContainerBuilder builder)
        {
        }

        public bool Validate(ref string errorMessage)
        {
            return true;
        }
    }
}