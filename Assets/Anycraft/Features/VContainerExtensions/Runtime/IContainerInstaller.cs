using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public interface IContainerInstaller
    {
        void Install(IContainerBuilder builder);
    }
}