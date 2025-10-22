using JetBrains.Annotations;
using VContainer;

namespace Anycraft.Features.Extenions.VContainer
{
    [UsedImplicitly]
    public interface IInstaller
    {
        void Install(IContainerBuilder builder);
    }
}