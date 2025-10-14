using JetBrains.Annotations;
using VContainer;

namespace Anycraft.FluentValidationExtensions.VContainerExtenions
{
    [UsedImplicitly]
    public interface IContainerInstaller
    {
        void Install(IContainerBuilder builder);
    }
}