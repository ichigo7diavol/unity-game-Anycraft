using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public interface IInstaller
    {
        void Install(IContainerBuilder builder);
    }
}