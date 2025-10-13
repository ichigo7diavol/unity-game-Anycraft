using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace Anycraft.Features.VContainerExtenions
{
    [UsedImplicitly]
    public abstract class ScriptableContainerInstaller : ScriptableObject, IContainerInstaller
    {
        public virtual void Install(IContainerBuilder builder)
        {
            UnityEngine.Assertions.Assert.IsNotNull(builder);
        }
    }
}